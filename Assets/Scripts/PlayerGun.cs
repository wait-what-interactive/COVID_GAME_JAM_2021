using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public GameObject bullet;
    public float shootRate = .5f;

    private GameObject _gun;
    private Transform _bulletSpawnPoint;

    private float _shootRate = .5f;
    private Character _character;

    void Start()
    {
        _character = transform.parent.GetComponent<Character>();
        _gun = transform.GetChild(0).gameObject;
        _bulletSpawnPoint = _gun.transform.GetChild(0);
        _shootRate = shootRate;
    }

    void Update()
    {
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
        _character.PlayShootAnimation();
        Vector3 rot = transform.rotation.eulerAngles;
        Instantiate(bullet, _bulletSpawnPoint.position, Quaternion.Euler(rot));
    }

    private void RotateGunToMouse()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 270);
    }
}
