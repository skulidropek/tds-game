using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    public int UpgradePoint { get; set; }
    public PlayerLevelSystem LevelSystem { get; set; }


    private void Start()
    {
        LevelSystem = GetComponent<PlayerLevelSystem>();
        ClearData();
        LoadData();
    }
    private void OnDisable()
    {
        SaveData();
    }
    private void Update()
    {
       if (LevelSystem.IsLevelUp())
       {
            UpgradePoint++;
            SaveData();
     }
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("UpgradePoint", UpgradePoint);
    }

    private void LoadData()
    {
        UpgradePoint = PlayerPrefs.GetInt("UpgradePoint");
    }

    public void ClearData()
    {
        PlayerPrefs.SetInt("UpgradePoint", 0);
        LoadData();
    }
}
