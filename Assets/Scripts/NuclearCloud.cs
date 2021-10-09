using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearCloud : MonoBehaviour
{
    public float radius = 1;
    public float damage = 0.1f;
    public float speed = 10f;
    public Vector2 dir;

    public float delay = .3f;

    private void Start()
    {
        radius = transform.localScale.x;
    }

    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);

        radius -= Time.deltaTime * speed;
        transform.localScale = Vector3.one * radius;

        if (radius <= 0.1)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UpdatePlayerSick(collision.transform.parent.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            delay -= Time.deltaTime;
            if(delay <= 0f)
            {
                delay = .1f;
                UpdatePlayerSick(collision.transform.parent.gameObject);
            }
        }
    }

    private void UpdatePlayerSick(GameObject player)
    {
        player.GetComponent<Character>().UpdateSick(damage);
    }

    public void SetDirection(Vector2 dir)
    {
        this.dir = dir;
    }
}
