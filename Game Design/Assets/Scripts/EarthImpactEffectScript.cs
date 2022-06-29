using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthImpactEffectScript : MonoBehaviour
{
    public GameObject earthImpactEffect;
    public AudioClip earthImpactSfx;
    public Vector3 position;
    public Quaternion rotation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            AudioSource.PlayClipAtPoint(earthImpactSfx, Camera.main.transform.position);
            GameObject effectInstance = (GameObject)Instantiate(earthImpactEffect, position, rotation);
        }
    }
}
