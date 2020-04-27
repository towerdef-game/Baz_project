using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDamage : MonoBehaviour
{
    // public stats stats;
    // public GameObject PowerUpEffect;
    public int multipler;
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject Prefabs;
    public int NewDamge = 6;
    void OnTriggerEnter(Collider Col)
    {
        if (Col.tag == "Player")
        {
            PickUpPowerUpDamage();
            Debug.Log("Picked up power up");
          
        }

    }



    public void PickUpPowerUpDamage()
    {
        Debug.Log("Picked up");
        //  Instantiate(PowerUpEffect, transform.position, transform.rotation);



        // Prefabs = GameObject.Find("Bullet");
        // bullet HealthIncrease = gameObject.GetComponentInParent(typeof(bullet)) as bullet;
        //bullet.BulletDamage *= multipler;
       //Prefabs = GameObject.getcomponent<>().damage = NewDamge;


        Destroy(gameObject);
    }

 
    
      
            
          
    
}
