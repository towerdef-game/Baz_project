using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public stats stats;
    private bool gameEnd = false;
    public SceneFader SceneFader;
    public string nextlevel = "level02";
    public int leveltounlock = 2;
    public SceneFader sceneFader;
    // Start is called before the first frame update
    void Start()
    {

    }
    
        
    

    // Update is called once per frame
    void Update()
    {
        if (gameEnd)
            return;
       if (stats.Health <= 0 )
        {
            GameOver(); 
        } 
    }

    public void GameOver()
    {
        gameEnd = true;
        SceneManager.LoadScene("Lose");
       // SceneFader.FadTo("Lose");
    }

   public void WinLevel()
    {
        PlayerPrefs.SetInt("LevelReached", leveltounlock);
        sceneFader.FadTo(nextlevel);
    }
}
