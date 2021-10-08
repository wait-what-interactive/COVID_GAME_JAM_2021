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

    void Start()
    {
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
        Instantiate(bullet, _bulletSpawnPoint.position, Quaternion.identity);
    }

    private void RotateGunToMouse()
    {
        Vector3 mousePos = Input.mousePosition;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x -= objectPos.x;
        mousePos.y -= objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 60));
    }
}
