using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // EIN Buildmanager für alle Nodes
    public static BuildManager BuildmanagerInstance;

    //Awake nur für Singleton-Instance
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
    public GameObject missileLauncherTurretPrefab;

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn (Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("No Moneeey!!!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret Build! Money Left: " + PlayerStats.Money);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
