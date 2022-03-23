using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public GameObject bullet;
    public float shootRate = .5f;
    public ParticleSystem shootParticles;

    private Transform _bulletSpawnPoint;

    private float _shootRate = .5f;
    private Character _character;

    private BulletPool _objectsPool;


    void Start()
    {
        _character = transform.parent.GetComponent<Character>();
        _bulletSpawnPoint = transform.GetChild(0);
        _shootRate = shootRate;

        _objectsPool = new BulletPool(7, bullet);
    }

    void Update()
    {
        if (_character.isolated)
            return;

        RotateGunToMouse();

        if(shootRate > 0f)
        {
            shootRate -= Time.deltaTime;
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
                shootRate = _shootRate;
            }
        }
    }

    private void Shoot()
    {
        if (shootParticles)
            shootParticles.Play();

        _character.PlayShootAnimation();
        Vector3 rot = transform.rotation.eulerAngles;
        GameObject _bullet = _objectsPool.GetObject();
        _bullet.transform.SetPositionAndRotation(_bulletSpawnPoint.position, Quaternion.Euler(rot));
        _bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 15f, ForceMode2D.Impulse);
    }

    private void RotateGunToMouse()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 270);

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.x > transform.position.x)
            _character.Flip(false);
        else
            _character.Flip(true);
    }
}
