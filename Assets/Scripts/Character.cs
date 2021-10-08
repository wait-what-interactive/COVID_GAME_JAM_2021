using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 15f;
    public SickIndicator sickIndicator;
    public LayerMask whatIsGround;

    private Rigidbody2D _rigidBody;
    private Collider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private bool _stairsMovement = false;
    Transform pointToAnotherFloor; 

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (_stairsMovement)
            MoveToAnotherFloor();

        if(Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (!_stairsMovement)
            Move();
    }

    private void MoveToAnotherFloor()
    {
        if (!pointToAnotherFloor)
            return;

        transform.position = Vector2.MoveTowards(transform.position, pointToAnotherFloor.position, speed * 3 * Time.deltaTime);

        if(Vector2.Distance(transform.position, pointToAnotherFloor.position) < 0.1f)
        {
            _stairsMovement = false;
            pointToAnotherFloor = null;
            _rigidBody.bodyType = RigidbodyType2D.Dynamic;
            _collider.isTrigger = false;
        }
    }

    private void Move()
    {
        transform.Translate(transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);

        if (Input.GetAxis("Horizontal") > 0)
            _spriteRenderer.flipX = false;

        else if (Input.GetAxis("Horizontal") < 0)
            _spriteRenderer.flipX = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Stairs"))
        {
            if (Input.GetAxis("Vertical") != 0)
            {
                pointToAnotherFloor = collision.GetComponent<Stairs>().GetPointMoveTo(Input.GetAxis("Vertical"));

                if (!pointToAnotherFloor) return;

                _stairsMovement = true;
                _rigidBody.bodyType = RigidbodyType2D.Kinematic;
                _collider.isTrigger = true;
            }
        }
    }

    private void Jump()
    {
        _rigidBody.velocity = Vector2.zero;
        _rigidBody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircleAll(transform.position, 0.02f, whatIsGround).Length > 0;
    }

    public void UpdateSick(float value)
    {
        sickIndicator.SetValue(sickIndicator.GetValue() + value);
    }
}