using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{

    public GameObject ui;
    public Text upgradeCost;
    public Text sellAmount;
    public Button upgradeButton;

    private Node target;

    public void setTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = target.turretBlueprint.upgradeCost.ToString() + "€";
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Done";
            upgradeButton.interactable = false;
        }

        sellAmount.text = target.turretBlueprint.sellCost + "€";

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.BuildmanagerInstance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.BuildmanagerInstance.DeselectNode();
    }

}
