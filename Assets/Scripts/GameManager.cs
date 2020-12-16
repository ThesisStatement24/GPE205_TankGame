using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public List<Controller> players;
    public List<Controller> enemies;

    public Text Score;
    public Text HighScore;



    private void Awake()
    {
        
        if(instance == null)
        {
            instance = this;

        } else {

            Destroy(gameObject);

        }

        

    }

    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        Score.text = "Score: " + UnityEngine.PlayerPrefs.GetInt("Score");
        HighScore.text = "HighScore: " + UnityEngine.PlayerPrefs.GetInt("HighScore");

        if(UnityEngine.PlayerPrefs.GetInt("HighScore") <= UnityEngine.PlayerPrefs.GetInt("Score"))
        {

            UnityEngine.PlayerPrefs.SetInt("HighScore", UnityEngine.PlayerPrefs.GetInt("Score"));

        }
        
    }
}
