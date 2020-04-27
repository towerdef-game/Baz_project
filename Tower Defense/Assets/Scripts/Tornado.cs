using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Wall")
        {
            Destroy(other.gameObject);

        }


        if (other.tag == "Turrets")
        {
            Destroy(other.gameObject);
        }


        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            waveSpawner.Enemiesalive--;
        }


        if (other.tag == "Player")
        {
            Debug.Log("hit");
            main_charcter.Health = 0;
            
           // Destroy(other.gameObject); 
        }
    }
}
