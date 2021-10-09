using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    public float speed = 10f;
    public GameObject destroyPS;

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
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("LevelBorder"))
        {
            if (destroyPS)
                Instantiate(destroyPS, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
