using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.BuildmanagerInstance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("StandardTurret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("MissileLauncherTurret Selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
    public void PurchaseTurret3()
    {
        Debug.Log("Turret purchased");
    }
}

