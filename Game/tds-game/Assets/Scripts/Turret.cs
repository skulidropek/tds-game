using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private float _bulletForce;
    [SerializeField] private GameObject _light;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletObj;

    bool _detected = false;
    private Vector2 _direction;
    private Vector2 _targetPos;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _direction = _firePoint.transform.position;

        RaycastHit2D _hit = Physics2D.CircleCast(transform.position, _range, _direction);

        if (_hit.collider != null)
        {
            Debug.Log(_hit.collider);
            if (_hit.collider.tag == "Enemy")
            {
                _targetPos = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>().position;
                _detected = true;
            }
        }
        else
        {
            _detected = false;
            _light.SetActive(false);
        }

        if (_detected)
        {
            Vector2 _lookDir = _targetPos - _rb.position;
            float _angle = Mathf.Atan2(_lookDir.y, _lookDir.x) * Mathf.Rad2Deg - 90f;
            _rb.rotation = _angle;
            _light.SetActive(true);
            Shoot();
            _detected = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _range);
    }

    private void Shoot()
    {
        GameObject _bullet = Instantiate(_bulletObj, _firePoint.position, _firePoint.rotation);
        Rigidbody2D _rbBullet = _bullet.GetComponent<Rigidbody2D>();
        _rbBullet.AddForce(_firePoint.up * _bulletForce, ForceMode2D.Impulse);
    }
}
