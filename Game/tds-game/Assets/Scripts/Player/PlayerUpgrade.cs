using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    public PlayerLevelSystem LevelSystem { get; set; }
    public int UpgradePoint { get; set; }

    private void Start()
    {
        LevelSystem = GetComponent<PlayerLevelSystem>();
    }

    private void Update()
    {
        if (LevelSystem.IsLevelUp())
        {
            UpgradePoint++;
        }
    }
}
