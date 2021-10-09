using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    static int currentLevel = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (EnemyController.spawnedEnemies.Count == 0)
        {
            currentLevel += 1;
            SceneManager.LoadScene("level" + currentLevel.ToString());
        }
    }
}
