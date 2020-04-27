using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeTurretSelecter : MonoBehaviour
{
    public GameObject ui;
    private Node target;
    public Text upgeadeCost;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();
        upgeadeCost.text = "£" + target.turretBlueprint.upgradeCost;
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeslectNode();
        // upgrading the turrets does not deleates the node and previous turret
    }

    public void Sell()
    {
        target.SellTurrets();
        BuildManager.instance.DeslectNode();
        //sell the turrets works fine.
    }
}
