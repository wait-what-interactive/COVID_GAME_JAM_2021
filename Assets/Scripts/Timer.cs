using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    int time = 10;
    private void Start()
    {
        StartCoroutine(Time_());
    }

    IEnumerator Time_()
    {
        for (int i = time; i >= 0; --i) 
        {
            yield return new WaitForSeconds(1);
            GetComponent<Text>().text = i.ToString();
        }
        SceneManager.LoadScene("Level" + GoToNextLevel.currentLevel.ToString());
    }
}
