using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    [Header("Audio")]
    public AudioClip buyTurretSfx;
    public AudioClip upgradeTurretSfx;
    public AudioClip sellTurretSfx;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.BuildmanagerInstance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        //UI elemente übereinander soll die Node nicht reagieren
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //Falls ein Turret schon auf der Node ist
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        //Falls kein Turret ausgewählt ist soll er nichts machen
        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("No Moneeey!!!");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        AudioSource.PlayClipAtPoint(buyTurretSfx, Camera.main.transform.position);

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);


        Debug.Log("Turret Build!");
    }

    public void UpgradeTurret()
    {
        if(PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("No Moneeey!!!");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //Alter Turret entfernen
        Destroy(turret);

        //Baue neue Turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        AudioSource.PlayClipAtPoint(upgradeTurretSfx, Camera.main.transform.position);
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("Turret Upgraded!");
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.sellCost;

        AudioSource.PlayClipAtPoint(sellTurretSfx, Camera.main.transform.position);
        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBlueprint = null;
    }

    void OnMouseEnter()
    {
        //UI elemente übereinander soll die Node nicht reagieren
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //Falls kein Turret ausgewählt ist soll er nichts machen
        if (!buildManager.CanBuild)
            return;

        //HoverFarbe der Node Abnhängig vom Geld
        if (buildManager.HasMoney)
            rend.material.color = hoverColor;
        else
            rend.material.color = notEnoughMoneyColor;
        
        
    }

    //Zurück auf die standardFarbe nach dem hover
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
