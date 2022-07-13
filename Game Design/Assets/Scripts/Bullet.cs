using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public GameObject impactEffect;

    public float speed = 60f;
    public float damage = 20;
    public float explosionRadius = 0f;
    public AudioClip missileLauncherExplosionSfx;


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
        transform.LookAt(target);

    }

    void HitTarget()
    {
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 5f);

        if (explosionRadius > 0f)
        {
            AudioSource.PlayClipAtPoint(missileLauncherExplosionSfx, Camera.main.transform.position);
            Explode();
        }
        else
            Damage(target);

        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e!= null)
            e.TakeDamage(damage);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
