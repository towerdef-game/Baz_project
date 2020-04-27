using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color notEnoughmoney;
    public Vector3 positionOffset;
    public string PlayerTag = "Player";
    public float buildrange = 15f;
    public bool InRange;

    [Header("Optional")]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;
    private Renderer Rend;
    //public ParticleSystem Buildeffect;

    private Color StartColor;

    BuildManager BuildManager;
    // Start is called before the first frame update
    void Start()
    {
        Rend = GetComponent<Renderer>();
        StartColor = Rend.material.color;

        BuildManager = BuildManager.instance;
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void Update()
    {
        GameObject Player = GameObject.FindGameObjectWithTag(PlayerTag);
        float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);
        if (distanceToPlayer < buildrange)
        {
            InRange = true;
           
        }
        if (distanceToPlayer > buildrange)
        {
            InRange = false;
        }
    }


    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            Debug.Log("Can't build there - TODO: Display on screen");
            BuildManager.SelectNode(this);
            return;
        }
        if (InRange == false)
        {
            return;
        }

        if (!BuildManager.CanBuild)
            return;

        BuildTurret(BuildManager.GetTurretToBuild());
    }

    public void BuildTurret(TurretBlueprint blueprint)
    {
        if (stats.Money < blueprint.cost)
        {
            return;
        }

        stats.Money -= blueprint.cost;
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.Euler(-90, 0, 0));
        turret = _turret;
      //  turret.transform.parent = node.transform;
        turretBlueprint = blueprint;
        GameObject effect = (GameObject)Instantiate(BuildManager.Buildeffect, GetBuildPosition(), Quaternion.identity); //Quaternion.identity
        Destroy(effect, 2f);
        turret.transform.parent = transform;
    }

    public void SellTurrets()
    {
        stats.Money += turretBlueprint.sellTurret();
        Destroy(turret);
        turretBlueprint = null;
    }

    public void UpgradeTurret()
    {
        if (stats.Money < turretBlueprint.upgradeCost)
        {
            return;
        }

        stats.Money -= turretBlueprint.upgradeCost;
        //geting rid of the old turret
        Destroy(turret);
        //building the new turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradePrefab, GetBuildPosition(), Quaternion.Euler(-90, 0, 0));
        turret = _turret;

        isUpgraded = true;
        turret.transform.parent = transform;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!BuildManager.CanBuild)
            return;

        if (BuildManager.HasMoney )
        {
            Rend.material.color = hoverColor;
        }
       // else 
        if(!InRange || !BuildManager.HasMoney) 
        {
            Rend.material.color = notEnoughmoney;
        }
    }

    public void OnMouseExit()
    {
        
        Rend.material.color = StartColor;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, buildrange);

    }
}
