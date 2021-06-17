using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _obj;
    [SerializeField] private float _cooldown;
    [SerializeField] private int _health;

    private float _timer;
    private void Update()
    {
        if (_timer <= 0)
        {
            Instantiate(_obj, transform.position, transform.rotation);
            _timer = _cooldown;
        }
        else
            _timer -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (IsDead())
            Destroy(gameObject);
    }

    public void TakeDamage(int damage) => _health -= damage;
    public bool IsDead() => _health <= 0;
}
