using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class moneycounter : MonoBehaviour
{
    public Text Money;
    void Update()
    {
        Money.text = "£" + stats.Money.ToString();
    }
}
