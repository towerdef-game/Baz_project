using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
   // public stats stats;
   // public GameObject PowerUpEffect;
    public int multipler = 2;
    // Start is called before the first frame update


    void OnTriggerEnter(Collider Col)
    {
        if (Col.tag == "Player")
        {
            PickUpPowerUp();
            Debug.Log("Picked up power up");
        }

    }

 

    public void PickUpPowerUp()
    {
        Debug.Log("Picked up");
      //  Instantiate(PowerUpEffect, transform.position, transform.rotation);

        stats HealthIncrease = GameManager.FindObjectOfType<stats>();
        stats.Health *= multipler;
        Destroy(gameObject);
    }
}
