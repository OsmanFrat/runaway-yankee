using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void playGameAndResetGame()
    {
        SceneManager.LoadScene("Prototype 3");
        Time.timeScale = 1.0f;
    }

    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }


    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
