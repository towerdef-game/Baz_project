using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
   


     void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More Than one buildManager");
            return;
        }

        instance = this;
    }

 

    public GameObject Buildeffect;

    private TurretBlueprint TurretBuild;
    private Node SelectedNode;
    public GameObject player;
    private main_charcter character;
    private TurretBlueprint trapbuild;
    public Camera came;
    
   
    public NodeTurretSelecter nodeUI;

    void Start()
    {
      
        //TurretBuild = GunPrefab; 
    }
    public bool CanBuild { get { return TurretBuild != null; } }
    public bool HasMoney { get { return stats.Money >= TurretBuild.cost; } }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = came.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (stats.Money < trapbuild.cost)
                {
                    return;
                }

                stats.Money -= trapbuild.cost;
                GameObject trap = (GameObject)Instantiate(trapbuild.prefab, hit.point, Quaternion.Euler(0, 0, 0));
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            TurretBuild = null;
            trapbuild = null;
        }

    }


    public void SelectNode(Node node)
    {
        SelectedNode = node;
        TurretBuild = null;
        nodeUI.SetTarget(node);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        TurretBuild = turret;
        DeslectNode();

       
    } 

    public void DeslectNode()
    {
        SelectedNode = null;
        nodeUI.Hide();

    }
    public void Trapbuild (TurretBlueprint trap)
    {
        trapbuild = trap;
    }
    

    public TurretBlueprint GetTurretToBuild()
    {
        return TurretBuild;
    }
}
