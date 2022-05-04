using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;

    private Transform target;
    private int waypointIndex = 0;

    private void Start()
    {
        target = Waypoints.waypoints[0];
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;   //Richtungsvektor für den Gegner
        transform.Translate(direction.normalized*speed*Time.deltaTime, Space.World); // Bewegt sich richtung Richtungsvektor

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)  // Gegner erreicht den Waypoint
        {
            GetNextWayPoint();
        }
    }

    //Nimmt den nächsten waypoint aus dem Array
    void GetNextWayPoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }
}
