using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public Button[] levelButtons;
    public SceneFader SceneFader;
        
    

    void Start()
    {
        int LevelReached = PlayerPrefs.GetInt("LevelReached", 1);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i + 1 > LevelReached)
            levelButtons[i].interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnMenu()
    {
       // SceneManager.LoadScene("Menu");
        SceneFader.FadTo("Menu");
    }

    public void SelectMenu()
    {
        //SceneManager.LoadScene("SampleScene");

        SceneFader.FadTo("SampleScene");

    }

    public void GameLevel2()
    {
       // SceneManager.LoadScene("Level2");
        SceneFader.FadTo("Level2");
    }

    public void GameLevel3()
    {
        //SceneManager.LoadScene("Level3");
        SceneFader.FadTo("Level3");
    }
}
