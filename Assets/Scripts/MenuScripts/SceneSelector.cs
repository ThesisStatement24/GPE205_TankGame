using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{

    public GameObject OUI;
    public GameObject MenuUI;


    public void StartGame()
    {
        Debug.Log("Start Game!");
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {

        SceneManager.LoadScene(0);

    }

    public void QuitGame()
    {

        Application.Quit();
        Debug.Log("Quitting Game!");

    }

    public void DeleteScores()
    {

        PlayerPrefs.DeleteKey("HighScore");

    }

    public void OptionsScreen()
    {

        MenuUI.SetActive(false);
        OUI.SetActive(true);

    }

    public void BacktoMenu()
    {

        MenuUI.SetActive(true);
        OUI.SetActive(false);

    }

}
