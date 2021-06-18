using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _speed;

    private static PlayerController controler;
    private static PlayerLevelSystem levelSystem;
    private static PlayerShooting shooting;

    public void Start()
    {
        controler = GetComponent<PlayerController>();
        levelSystem = GetComponent<PlayerLevelSystem>();
        shooting = GetComponent<PlayerShooting>();

    }

    private void Update()
    {
        controler.Speed = _speed;

        if (levelSystem.Wipe)
        {
            _speed *= 2;
            Debug.Log("Ваша скорость x2");
            levelSystem.Wipe = false;
            levelSystem.DataClear();
        }

        if (IsDead())
        {
            SceneManager.LoadScene(0);
            Destroy(gameObject);
        }

    }

    public void TakeDamage(int damage) => _health -= damage;
    public bool IsDead() => _health <= 0;
}
