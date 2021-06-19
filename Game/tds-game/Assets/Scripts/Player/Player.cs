using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int _healthMax;
    [SerializeField] private float _speed;
    [SerializeField] private HealthBar _healthBar;

    private static PlayerController controler;
    private static PlayerLevelSystem levelSystem;
    private static PlayerShooting shooting;

    private int _health;

    public void Start()
    {
        _health = _healthMax;
        controler = GetComponent<PlayerController>();
        levelSystem = GetComponent<PlayerLevelSystem>();
        shooting = GetComponent<PlayerShooting>();
        _healthBar.SetMaxHealth(_healthMax);
    }

    private void Update()
    {
        _healthBar.SetHealth(_health);

        controler.Speed = _speed;

        if (IsDead())
        {
            SceneManager.LoadScene(0);
            Destroy(gameObject);
        }

    }

    public void TakeDamage(int damage) => _health -= damage;
    public bool IsDead() => _health <= 0;
}
