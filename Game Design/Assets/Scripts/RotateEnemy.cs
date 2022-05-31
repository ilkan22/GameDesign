using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEnemy : MonoBehaviour
{
    public float Y = 90.0f;
    public float speed = 1.0f;
    private bool rotater = false;
    private GameObject Enemy;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Rot")
        {
            rotater = true;
        }
    } 
    void Update()
    {
        if (rotater)
        {
            Enemy.transform.Rotate(0, Y, 0);
        }
    }
}
