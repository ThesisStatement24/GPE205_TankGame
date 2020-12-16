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

        Score.text = "Your Score: " + UnityEngine.PlayerPrefs.GetInt("Score");
        HighScore.text = "HighScore: " + UnityEngine.PlayerPrefs.GetInt("HighScore");

        if (UnityEngine.PlayerPrefs.GetInt("HighScore") <= UnityEngine.PlayerPrefs.GetInt("Score"))
        {

            UnityEngine.PlayerPrefs.SetInt("HighScore", UnityEngine.PlayerPrefs.GetInt("Score"));

        }

    }
}
