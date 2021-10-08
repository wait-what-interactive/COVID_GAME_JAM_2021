using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector2 dir;

    public float speed = 5;
    public bool isSick = true;

    public float HP = 1;
    public bool haveMask = false;

    private void Start()
    {
        dir = Vector2.right;

        if(Random.Range(0,2) == 0)
            dir = Vector2.left;
    }

    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            HP -= collision.GetComponent<Bullet>().GetDamage();
            if (HP <= 0)
            {
                haveMask = true;
                transform.GetChild(0).gameObject.SetActive(false);
            }

            return;
        }

        if(collision.CompareTag("LevelBorder"))
        {
            dir = dir == Vector2.left ? Vector2.right : Vector2.left;
            return;
        }

        if (collision.gameObject == gameObject.transform.parent.GetChild(1).gameObject)
        {
            dir = Vector2.left;
            return;
        }

        if (collision.gameObject == gameObject.transform.parent.GetChild(2).gameObject)
        {
            dir = Vector2.right;
            return;
        }
    }
}
