using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScores : MonoBehaviour
{
    public Text Score;
    public Text HighScore;


    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        Score.text = "Your Score: " + PlayerPrefs.GetInt("Score");
        HighScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");

        if (PlayerPrefs.GetInt("HighScore") <= PlayerPrefs.GetInt("Score"))
        {

            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));

        }

    }
}
