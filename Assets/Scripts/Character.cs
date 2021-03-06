using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 15f;
    public SickIndicator sickIndicator;
    public LayerMask whatIsGround;
    [HideInInspector] public bool isolated = false;

    private Rigidbody2D _rigidBody;
    private Collider2D _collider;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _stairsMovement = false;
    private bool _jumping = false;
    Transform pointToAnotherFloor; 
    bool canMove = true;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (!canMove || isolated)
            return;

        if (_stairsMovement)
        {
            MoveToAnotherFloor();
            return;
        }


        if (IsGrounded() && _jumping)
        {
            _jumping = false;
            EndJump();
        }

        if (Input.GetKey(KeyCode.Space) && IsGrounded() && !_jumping)
        {
            Jump();
        }

    }

    private void FixedUpdate()
    {
        if (!canMove)
            return;

        if (!_stairsMovement)
            Move();
    }

    private void MoveToAnotherFloor()
    {
        if (!pointToAnotherFloor)
            return;

        transform.position = Vector2.MoveTowards(transform.position, pointToAnotherFloor.position, speed * 2 * Time.deltaTime);

        if(Mathf.Abs(Vector2.Distance(transform.position, pointToAnotherFloor.position)) <= 0.25f)
        {
            _rigidBody.velocity = Vector2.zero;
            _collider.isTrigger = false;
            _rigidBody.bodyType = RigidbodyType2D.Dynamic;
            _stairsMovement = false;
            pointToAnotherFloor = null;
        }
    }

    private void Move()
    {
        if(Input.GetAxis("Horizontal") == 0)
        {
            _animator.SetBool("Run", false);
            return;
        }
        _animator.SetBool("Run", true);
        transform.Translate(transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);

        if (Input.GetAxis("Horizontal") > 0)
            Flip(false);

        else if (Input.GetAxis("Horizontal") < 0)
            Flip(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Stairs"))
        {
            if (Input.GetAxis("Vertical") != 0)
            {
                pointToAnotherFloor = collision.GetComponent<Stairs>().GetPointMoveTo(Input.GetAxis("Vertical"));

                if (!pointToAnotherFloor) return;

                _rigidBody.velocity = Vector2.zero;
                _stairsMovement = true;
                _rigidBody.bodyType = RigidbodyType2D.Kinematic;
                _collider.isTrigger = true;

            }
        }
    }

    private void Jump()
    {
        _animator.SetBool("Jump", true);
        _rigidBody.velocity = Vector2.zero;
        _rigidBody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        _jumping = true;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircleAll(transform.position, 0.02f, whatIsGround).Length > 0;
    }

    public void UpdateSick(float value)
    {
        sickIndicator.SetValue(sickIndicator.GetValue() + value);
    }

    public void PlayShootAnimation()
    {
        _animator.SetBool("Shoot", true);
    }

    public void PlayIsolationAnimation()
    {
        _animator.SetTrigger("Isolate");
        isolated = true;
    }

    public void EndShoot()
    {
        _animator.SetBool("Shoot", false);
    }

    public void EndJump()
    {
        _animator.SetBool("Jump", false);
    }
    
    public void StopMoving()
    {
        print("here");
        canMove = false;
    }

    public void ResetMoving()
    {
        canMove = true;
    }

    public void Flip(bool flip)
    {
        _spriteRenderer.flipX = flip;
    }
}