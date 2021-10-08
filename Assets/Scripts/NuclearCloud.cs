using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearCloud : MonoBehaviour
{
    public float radius = 1;
    public float damage = 0.1f;
    public float speed = 1f;

    private void Start()
    {
        radius = transform.localScale.x;
    }

    void Update()
    {
        radius -= Time.deltaTime;
        transform.localScale = Vector3.one * radius;

        if (radius <= 0.1)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<Character>().UpdateSick(damage);
    }
}
