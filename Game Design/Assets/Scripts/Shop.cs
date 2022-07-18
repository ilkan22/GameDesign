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
    public Button[] turretItems;

    
    private void Start()
    {
        buildManager = BuildManager.BuildmanagerInstance;

        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < turretItems.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                turretItems[i].interactable = false;
            }
            /*else if(i + 1 == levelReached)
            {
                levelButtons[i].interactable = false;
            }*/
        }
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

