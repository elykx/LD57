using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Level CurrentLevel;

    private void Awake()
    {
        G.levelManager = this;
    }

    public void LoadLevel(int levelNumber)
    {
        switch (levelNumber)
        {
            case 1:
                CurrentLevel = new Level("Level 1 bla-bla-bla", "Взломать защиту системы", 1, 3, new() { new EliminateAllEnemiesQuest() });
                CurrentLevel.Enemies = EnemiesConst.FirsLevelEnemies.ToList();
                break;
            case 2:
                CurrentLevel = new Level("Level 2", "Уничтожить ядро защиты", 2, 4, new() { new EliminateAllEnemiesQuest() });
                CurrentLevel.Enemies = EnemiesConst.SecondLevelEnemies.ToList();
                break;
        }
        // TODO: Хуйня течет где-то
        G.enemyManager.SetupEnemies(CurrentLevel.Enemies);
        G.ui.SetLevelUI(CurrentLevel);
        G.ui.SetPlayerUI(G.playerManager.Player);
    }

    public void CheckCompleteLevel()
    {
        CurrentLevel.CheckCompletion();
    }

    public void RestartLevel()
    {
        LoadLevel(CurrentLevel.LevelNumber);
    }
}
