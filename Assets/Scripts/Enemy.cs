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
    public float minTimeToSpawnCloud = 4;
    public float maxTimeToSpawnCloud = 15;
    public GameObject nuclearCloud;
    bool canMove = true;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    Coroutine spawnCoroutine;
    Coroutine stopingCoroutine;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        dir = Vector2.right;

        if(Random.Range(0,2) == 0)
            dir = Vector2.left;

        float time = Random.Range(minTimeToSpawnCloud, maxTimeToSpawnCloud);
        spawnCoroutine = StartCoroutine(SpawnCloud(time));
        stopingCoroutine = StartCoroutine(StopEnemy(time - 2));
    }

    void Update()
    {
        if (!canMove)
        {
            _animator.SetBool("Run", false);
            return;
        }
        Move();
    }

    private void Move()
    {
        if (HP <= 0)
            return;

        if (dir == Vector2.right)
            _spriteRenderer.flipX = false;

        if (dir == Vector2.left)
            _spriteRenderer.flipX = true;

        transform.Translate(dir * speed * Time.deltaTime);
        _animator.SetBool("Run", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            HP -= collision.GetComponent<Bullet>().GetDamage();
            if (HP <= 0)
            {
                _animator.SetBool("Isolated", true);
                haveMask = true;
                EnemyController.RemoveEnemy(gameObject);
                transform.GetChild(0).gameObject.SetActive(false);
                StopCoroutine(spawnCoroutine);
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

    IEnumerator SpawnCloud(float time)
    {
        yield return new WaitForSeconds(time);
        //spawn cloud

        _animator.SetBool("Attack", true);

        float time_ = Random.Range(minTimeToSpawnCloud, maxTimeToSpawnCloud);
        spawnCoroutine = StartCoroutine(SpawnCloud(time_));
        stopingCoroutine = StartCoroutine(StopEnemy(time - 2));
    }

    public void SpawnCloudFunction()
    {
        var cloud = Instantiate(nuclearCloud, transform.position, Quaternion.identity);
        cloud.GetComponent<NuclearCloud>().SetDirection(dir);
    }

    IEnumerator StopEnemy(float time)
    {
        yield return new WaitForSeconds(time);
        canMove = false;
        StartCoroutine(ResetMovementEnemy(2));
    }

    IEnumerator ResetMovementEnemy(float time)
    {
        yield return new WaitForSeconds(time);
        canMove = true;
    }

    public void StopAttack()
    {
        _animator.SetBool("Attack", false);
    }
}
