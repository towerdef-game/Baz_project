using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class main_charcter : MonoBehaviour
{
    public Camera came;
    public NavMeshAgent agent;
    public LayerMask groundlayer;
  //  int groundlayer = LayerMask.GetMask("ground");
    BuildManager BuildManager;
    public static int Health;
    public int startHealth = 5;
    private playerspawner lifesaver;


    void Start()
    {
        came = Camera.main;
        GameObject spawner = GameObject.FindGameObjectWithTag("spawn");
        lifesaver = spawner.GetComponent<playerspawner>();
        Health = startHealth;
        BuildManager = BuildManager.instance;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = came.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.tag == "ground")
                {
                    agent.SetDestination(hit.point);
                }
             //   agent.SetDestination(hit.point);
            }
        }
        if(Health <= 0)
        {
            Destroy(gameObject);
            lifesaver.playerdied = true;
                     
        }
    }
    
}
