using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    public static int currentLevel = 1;

    private void Awake()
    {
        Camera.main.GetComponent<Animator>().SetTrigger("FadeOut");
    }

    private IEnumerator LoadScene(string name)
    {
        Camera.main.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(EnemyController.spawnedEnemies.Count);
        if (EnemyController.spawnedEnemies.Count == 0)
        {
            currentLevel += 1;
            if(currentLevel < 11)
                StartCoroutine(LoadScene("Level" + currentLevel.ToString()));
            else
                StartCoroutine(LoadScene("Menu"));
        }
    }
}
