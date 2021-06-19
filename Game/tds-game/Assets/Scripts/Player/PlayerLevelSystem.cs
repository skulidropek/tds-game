using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLevelSystem : MonoBehaviour
{
    [SerializeField] private ExpirienceBar _expirienceBar;
    [SerializeField] private TextMeshProUGUI _lvlText;
    public int Lvl { get; set; }
    public int Exp { get; set; }
    public int MaxExp { get; set; }

    private void Start()
    {
        ClearData();
        MaxExp = 100;
        LoadData();
    }

    private void OnDisable()
    {
        SaveData();
    }

    private void Update()
    {
        _lvlText.text = Lvl.ToString();
        if (IsLevelUp())
        {
            Lvl++;
            Exp = 0;
            MaxExp += MaxExp / 2;
        }

        _expirienceBar.SetXP(Exp);
        _expirienceBar.SetMaxXP(MaxExp);
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("Level", Lvl);
        PlayerPrefs.SetInt("Exp", Exp);
        PlayerPrefs.SetInt("ExpNextLvl", MaxExp);
    }

    private void LoadData()
    {
       Lvl = PlayerPrefs.GetInt("Level");
       Exp = PlayerPrefs.GetInt("Exp");
       MaxExp = PlayerPrefs.GetInt("ExpNextLvl") == 0 ? 20 : PlayerPrefs.GetInt("ExpNextLvl");
    }

    public void ClearData()
    {
        PlayerPrefs.SetInt("Level", 0);
        PlayerPrefs.SetInt("Exp", 0);
        PlayerPrefs.SetInt("ExpNextLvl", 0);
        LoadData();
    }
    public bool IsLevelUp() => MaxExp <= Exp; 
}
