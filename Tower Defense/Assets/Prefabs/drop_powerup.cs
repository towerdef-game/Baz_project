using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop_powerup : MonoBehaviour
{
    public GameObject powerup;
    // Start is called before the first frame update
    void DROP()
    {
        Instantiate(powerup, transform.position, transform.rotation);
    }   
}
