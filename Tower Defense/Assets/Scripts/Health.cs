using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text Healthtext;
    

   
    void Update()
    {
        Healthtext.text = stats.Health + " Health";
    }
}
