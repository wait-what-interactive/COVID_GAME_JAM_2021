using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void StartGame()
    {
        GoToNextLevel.currentLevel = 1;
        SceneManager.LoadScene("Level1");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Level"+ GoToNextLevel.currentLevel.ToString());
    }
}
