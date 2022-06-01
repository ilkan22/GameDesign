using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 1.0f;

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed, Space.World);
    }
}