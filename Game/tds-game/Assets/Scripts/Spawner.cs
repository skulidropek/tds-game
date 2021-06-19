using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _obj;
    [SerializeField] private int _spawnCount;
    [SerializeField] private float _cooldownRespawn;
    [SerializeField] private float _cooldownSpawn;
    [SerializeField] private float _cooldownDespawn;
    [SerializeField] private int _health;

    private float _timerRespawn;
    private float _timerSpawn;
    private void Update()
    {
        if (_timerSpawn >= _cooldownSpawn && _timerSpawn <= _cooldownDespawn)
        {
            if(_timerRespawn <= 0)
            {
                for (int i = 0; i < _spawnCount; i++)
                    Instantiate(_obj, transform.position, transform.rotation);
                _timerRespawn = _cooldownRespawn;
            }
            else
            {
                _timerRespawn -= Time.deltaTime;
            }
        }
        _timerSpawn += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (IsDead())
            Destroy(gameObject);
    }

    public void TakeDamage(int damage) => _health -= damage;
    public bool IsDead() => _health <= 0;
}