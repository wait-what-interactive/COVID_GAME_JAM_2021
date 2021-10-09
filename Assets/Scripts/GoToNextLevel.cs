using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    static int currentLevel = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(EnemyController.spawnedEnemies.Count);
        if (EnemyController.spawnedEnemies.Count == 0)
        {
            currentLevel += 1;
            if(currentLevel<11)
                SceneManager.LoadScene("Level" + currentLevel.ToString());
            else
                SceneManager.LoadScene("Menu");
        }
    }
}
