using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelSystem : MonoBehaviour
{
    [SerializeField] private Text _lvlText;
    [SerializeField] private Text _expText;

    private int _lvl;
    private int _exp;
    private int _expNextLvl;

    private void Start()
    {
        _lvl = 0;
        _exp = 0;
        _expNextLvl = 20;
    }

    private void FixedUpdate()
    {
        if(IsLevelUp())
        {
            LevelUp(1);
            _exp = 0;
            _expNextLvl += _expNextLvl / 2;
        }

        _lvlText.text = _lvl.ToString();
        _expText.text = $"{_exp}/{_expNextLvl}";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Exp") && gameObject.CompareTag("Player"))
        {
            ExpUp(1);
            Destroy(collision.gameObject);
        }
    }

    private void ExpUp(int count) =>_exp += count;
    private void LevelUp(int count) => _lvl += count;
    private bool IsLevelUp() => _expNextLvl < _exp; 
}
