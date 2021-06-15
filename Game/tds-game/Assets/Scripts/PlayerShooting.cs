using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletObj;
    [SerializeField] private float _bulletForce;

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
        //_bullet.transform.Translate(Vector2.up * 10f * Time.deltaTime);//_firePoint.up * _bulletForce);
        Rigidbody2D _rb = _bullet.GetComponent<Rigidbody2D>();
        _rb.AddForce(_firePoint.up * _bulletForce, ForceMode2D.Impulse);
      //  _rb.velocity *= 20;
    }

    private void Speed()
    {

    }
}
