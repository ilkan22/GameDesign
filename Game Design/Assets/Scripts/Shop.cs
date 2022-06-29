using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint LaserBeamer;

    //public Button StandardTurretButton;

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
    public void SelectLaserBeamer()
    {
        Debug.Log("LaserBeamer Selected");
        buildManager.SelectTurretToBuild(LaserBeamer);
    }
}

