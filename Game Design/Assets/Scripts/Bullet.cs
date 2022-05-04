using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public GameObject impactEffect;

    private float speed = 60f;


    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        //Falls die Kugel keinen Gegner mehr hat
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 directionToEnemy = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        //Gegner getroffen
        if (directionToEnemy.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(directionToEnemy.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 2f);

        Destroy(target.gameObject);
        Destroy(gameObject);

    }
}
