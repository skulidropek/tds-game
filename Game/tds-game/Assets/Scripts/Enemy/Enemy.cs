using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _cooldown;

    private float _reloadTime;

    private void Start()
    {
        GetComponent<NavMeshAgent>().speed *= _speed;
    }

    private void Update()
    {
        if (IsDead())
        {
            Destroy(gameObject);

            PlayerLevelSystem levelSystem = GameObject.Find("Player").GetComponent<PlayerLevelSystem>();
            levelSystem.Exp += 2;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(_reloadTime <= 0)
            {
                Player player = collision.gameObject.GetComponent<Player>();
                player.TakeDamage(1);
                _reloadTime = _cooldown;
            }
            else
            {
                _reloadTime -= Time.deltaTime;
            }
        }
    }

    public void TakeDamage(int damage) => _health -= damage;

    public bool IsDead() => _health <= 0;
}
