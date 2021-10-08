using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector2 dir;

    public float speed = 5;
    public bool isSick = true;

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
