using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int _healthMax;
    [SerializeField] private float _speed;
    [SerializeField] private HealthBar _healthBar;

    public PlayerController Controler { get; set; }
    public PlayerLevelSystem LevelSystem { get; set; }
    public PlayerShooting Shooting { get; set; }
    public PlayerUpgrade Upgrade { get; set; }
    public float Speed { get; set; }
    private int HealthMax { get; set; }

    private int _health;

    public void Start()
    {

        Speed = _speed;
        HealthMax = _healthMax;

        Controler = GetComponent<PlayerController>();
        LevelSystem = GetComponent<PlayerLevelSystem>();
        Shooting = GetComponent<PlayerShooting>();
        Upgrade = GetComponent<PlayerUpgrade>();

        _health = HealthMax;
        _healthBar.SetMaxHealth(HealthMax);
    }

    private void Update()
    {
        _healthBar.SetHealth(_health);

        Controler.Speed = Speed;

        if (IsDead())
        {
            SceneManager.LoadScene(0);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage) => _health -= damage;
    public bool IsDead() => _health <= 0;

    //public void SaveData()
    //{
    //    PlayerPrefs.SetInt("HealthMax", _healthMax);
    //    PlayerPrefs.SetFloat("Speed", _speed);
    //}
    //public void LoadData()
    //{
    //    _healthMax = PlayerPrefs.GetInt("HealthMax") == 0 ? _healthMax : PlayerPrefs.GetInt("HealthMax");
    //    _speed = PlayerPrefs.GetFloat("Speed") == 0 ? _speed : PlayerPrefs.GetInt("Speed");
    //}
}
