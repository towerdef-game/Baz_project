using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private bool gameOver = false;
    // Update is called once per frame
    void Update()
    {
        if (gameOver)
            return;

        if (stats.Health <= 0)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        gameOver = true;
    }
}
