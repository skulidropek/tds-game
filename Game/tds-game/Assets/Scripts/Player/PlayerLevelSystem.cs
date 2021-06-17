using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelSystem : MonoBehaviour
{
    [SerializeField] private Text _lvlText;
    [SerializeField] private Text _expText;

    public bool Wipe { get; set; }
    public int Lvl { get; set; }
    public int Exp { get; set; }
    public int ExpNextLvl { get; set; }

    private void Start()
    {
        LoadData();
    }

    private void OnDisable()
    {
        SaveData();
    }

    private void Update()
    {
        if(IsLevelUp())
        {
            Lvl++;
            Exp = 0;
            ExpNextLvl += ExpNextLvl / 2;
        }

        Wipe = Lvl >= 10;

        _lvlText.text = Lvl.ToString();
        _expText.text = $"{Exp}/{ExpNextLvl}";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Exp") && gameObject.CompareTag("Player"))
        {
            Exp++;
            Destroy(collision.gameObject);
        }
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("Level", Lvl);
        PlayerPrefs.SetInt("Exp", Exp);
        PlayerPrefs.SetInt("ExpNextLvl", ExpNextLvl);
    }

    private void LoadData()
    {
       Lvl = PlayerPrefs.GetInt("Level");
       Exp = PlayerPrefs.GetInt("Exp");
       ExpNextLvl = PlayerPrefs.GetInt("ExpNextLvl") == 0 ? 20 : PlayerPrefs.GetInt("ExpNextLvl");
    }

    public void DataClear()
    {
        PlayerPrefs.SetInt("Level", 0);
        PlayerPrefs.SetInt("Exp", 0);
        PlayerPrefs.SetInt("ExpNextLvl", 0);
        LoadData();
    }
 //   public void ExpUp(int count) => Exp += count;
  //  public void LevelUp(int count) => Lvl += count;
    public bool IsLevelUp() => ExpNextLvl < Exp; 
}
