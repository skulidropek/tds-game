using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletObj;
    [SerializeField] private float _bulletForce;
    //[SerializeField] private LayerMask _maskIsSolid;
    // private int _distance = 2;



    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject _bullet = Instantiate(_bulletObj, _firePoint.position, _firePoint.rotation);
        Rigidbody2D _rb = _bullet.GetComponent<Rigidbody2D>();
        _rb.AddForce(_firePoint.up * _bulletForce, ForceMode2D.Impulse);
    }
}
