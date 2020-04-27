using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PowerUpSpeed : MonoBehaviour
{
     // public stats stats;
   // public GameObject PowerUpEffect;
    public int multipler = 3;
    // Start is called before the first frame update
    public GameObject Player;
    public float randSpeed = 10;
    private bool speedIncrease;
    public int newSpeed = 6;

    //UnityEngine.AI.NavMeshAgent navMeshAgent;

    void OnTriggerEnter(Collider Col)
    {
        if (Col.tag == "Player")
        {
            PickUpPowerUpSpeed();
            Debug.Log("Picked up power up");
          

        }

    }

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("player");
    }

    public void PickUpPowerUpSpeed()
    {
        Debug.Log("Picked up");
        //  Instantiate(PowerUpEffect, transform.position, transform.rotation);
        Player.GetComponent<NavMeshAgent>().speed = newSpeed;

        Destroy(gameObject);
    }
}
