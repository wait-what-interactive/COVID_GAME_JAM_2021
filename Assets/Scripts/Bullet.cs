using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    public float speed = 10f;
    public GameObject destroyPS;
    public GameObject hitEnemyPS;
    public GameObject sound;

    private void Start()
    {
        Destroy(Instantiate(sound, transform.parent), 2);
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public int GetDamage()
    {
        return damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("LevelBorder"))
        {
            if (destroyPS)
                Instantiate(destroyPS, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (hitEnemyPS)
            {
                Instantiate(hitEnemyPS, transform.position, Quaternion.identity);

            }

            Destroy(gameObject);
            return;
        }
    }
}
