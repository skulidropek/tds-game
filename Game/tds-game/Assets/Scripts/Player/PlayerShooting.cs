using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletObj;
    [SerializeField] private float _bulletForce;
    [SerializeField] private float _cooldown;

    private bool _fire;
    private float _reloadTime;
    //[SerializeField] private LayerMask _maskIsSolid;
    // private int _distance = 2;


    private void Update()
    {
        _fire = Input.GetButton("Fire1");
    }

    private void FixedUpdate()
    {
        if (_fire && _reloadTime <= 0)
        {
            Shoot();
            _reloadTime = _cooldown;
        }
        else
        {
            _reloadTime -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        GameObject _bullet = Instantiate(_bulletObj, _firePoint.position, _firePoint.rotation);
        Rigidbody2D _rb = _bullet.GetComponent<Rigidbody2D>();
        _rb.AddForce(_firePoint.up * _bulletForce, ForceMode2D.Impulse);
    }
}
