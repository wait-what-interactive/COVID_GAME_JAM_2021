using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private void Awake()
    {
        
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            Camera.main.GetComponent<Animator>().SetTrigger("FadeOut");
            UnPause();
        }
    }

    private IEnumerator PlayAnimAndLoadGame()
    {
        Camera.main.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(1.1f);
        GoToNextLevel.currentLevel = 1;
        SceneManager.LoadScene("Level1");
    }

    public void StartGame()
    {
        StartCoroutine(PlayAnimAndLoadGame());
    }

    private IEnumerator PlayAnimAndLoadMenu()
    {
        Camera.main.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene("Menu");
    }

    private IEnumerator PlayAnimAndReload()
    {
        Camera.main.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene("Level" + GoToNextLevel.currentLevel.ToString());
    }

    public void LoadMenu()
    {
        StartCoroutine(PlayAnimAndLoadMenu()); 
        UnPause();
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
