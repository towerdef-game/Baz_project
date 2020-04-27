using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerspawner : MonoBehaviour
{
   
    public bool playerdied = false;
    private float respawn;
    public Transform playerspawnpoint;
    public float countdown =5f;
    public GameObject player;

     void Start()
    {
        respawn = countdown;
    }
    // Update is called once per frame
    void Update()
    {
       if(playerdied == true)
        {
          //  respawn = countdown;
            respawn -= Time.deltaTime;          
        }
       if(respawn < 0)
       {
            spawn();          
       }
    }
  void spawn()
    {       
        
        playerdied = false;
        Instantiate(player, playerspawnpoint.position, playerspawnpoint.rotation);
        respawn = countdown;
    }
}
