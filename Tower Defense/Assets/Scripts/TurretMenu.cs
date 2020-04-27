using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretMenu : MonoBehaviour
{

    public bool toggle = false;
    public bool toggletrap = false;
    public GameObject turretMenuShop;
   // public GameObject trapMenuShop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turnTurretMenuOf()
    {

        if (!toggle)
        {
            turretMenuShop.SetActive(true);
            toggle = true;

        }
        else
        {
            turretMenuShop.SetActive(false);
            toggle = false;
        }
    }
/*
    public void turnTrapMenuOf()
    {

        if (!toggletrap)
        {
            trapMenuShop.SetActive(true);
            toggletrap = true;

        }
        else
        {
            trapMenuShop.SetActive(false);
            toggletrap = false;
        }
    }
    */
}
