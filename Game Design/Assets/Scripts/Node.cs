using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

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
        //Falls kein Turret ausgewählt ist soll er nichts machen
        if (!buildManager.CanBuild)
            return;

        //Falls ein Turret schon auf der Node ist
        if (turret != null)
        {
            Debug.Log("TO DO: BILDSCHIRM ANZEIGE");
            return;
        }

        buildManager.BuildTurretOn(this);
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
