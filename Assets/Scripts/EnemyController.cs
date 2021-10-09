using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float firstLevelSpawn;
    public float secondLevelSpawn;

    public int count;
    public GameObject player;
    public List<GameObject> enemies;
    public GameObject rightWall;
    public GameObject leftWall;

    public static List<GameObject> spawnedEnemies;

    void Start()
    {
        spawnedEnemies = new List<GameObject>();

        for (int i = 0; i < count; ++i) 
        {
            Vector3 enemyPos=Vector3.zero;

            if(Random.Range(0,2) == 0)
                enemyPos = new Vector2(Random.Range(leftWall.transform.position.x + 1, rightWall.transform.position.x - 1 ), secondLevelSpawn);
            else
            {
                float xPos;

                do
                {
                    xPos = Random.Range(leftWall.transform.position.x + 1, rightWall.transform.position.x - 1);
                } while (!(player.transform.position.x < xPos + 3 && (player.transform.position.x > xPos - 3)));

                enemyPos = new Vector2(xPos, firstLevelSpawn);
            }

            spawnedEnemies.Add(Instantiate(enemies[Random.Range(0, enemies.Count)], enemyPos, Quaternion.identity));
        }
        Destroy(gameObject);
    }

    public static void RemoveEnemy(GameObject enemy)
    {
        spawnedEnemies.Remove(enemy);

        if(spawnedEnemies.Count==0)
        {
            //go to next level
        }
    }
}
