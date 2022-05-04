using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // EIN Buildmanager für alle Nodes
    public static BuildManager BuildmanagerInstance;

    private void Awake()
    {
        if (BuildmanagerInstance != null)
        {
            Debug.LogError("Mehr als ein BuildManager in der Szene!!!");
            return;
        }
        BuildmanagerInstance = this;
    }

    public GameObject standardTurretPrefab;

    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild ()
    {
        return turretToBuild;
    }
}
