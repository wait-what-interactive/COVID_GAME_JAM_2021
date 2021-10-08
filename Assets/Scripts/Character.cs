using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);

        if (Input.GetAxis("Horizontal") > 0)
            _spriteRenderer.flipX = false;

        else if (Input.GetAxis("Horizontal") < 0)
            _spriteRenderer.flipX = true;
    }
}