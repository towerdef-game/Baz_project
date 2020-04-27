using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalWavesSurvived : MonoBehaviour
{
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        //scoreText.text = stats.Rounds.ToString();

        StartCoroutine(TextAnimate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TextAnimate()
    {
        scoreText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(1f);

        while (round < stats.Rounds)
        {
            round++;
            scoreText.text = round.ToString();
            yield return new WaitForSeconds(.1f);
        }
    }
}
