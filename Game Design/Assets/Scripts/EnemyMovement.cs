using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    public float rotationSpeed = 1f;

    private Transform target;
    private int waypointIndex = 0;

    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.waypoints[0];
    }
  private void Update()
    {
        Vector3 direction = target.position - transform.position;   //Richtungsvektor für den Gegner

        //Rotiert richtig
        Quaternion lookRotation = Quaternion.LookRotation(-direction);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(rotation);


        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World); // Bewegt sich richtung Richtungsvektor

        if (Vector3.Distance(transform.position, target.position) <= 0.5f)  // Gegner erreicht den Waypoint
            GetNextWayPoint();

        // Speed nach Laser zurückgesetzt funktioniert wegen UpdateLoop | Offset vlt bei 1Frame
        enemy.speed = enemy.startSpeed;
    }

    //Nimmt den nächsten waypoint aus dem Array
    public void GetNextWayPoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)    //Letzer Waypoint
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }

    void EndPath()
    {
        PlayerStats.reduceLives();
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

}
