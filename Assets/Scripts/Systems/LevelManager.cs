using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public Level CurrentLevel;

    private void Awake()
    {
        G.levelManager = this;
    }

    // Загрузка уровня
    public void LoadLevel(int levelNumber)
    {
        // Здесь можно добавить разные уровни
        switch (levelNumber)
        {
            case 1:
                CurrentLevel = new Level("Level 1 bla-bla-bla", "Взломать защиту системы", 1, 3, new() { new EliminateAllEnemiesQuest() });
                break;
            case 2:
                CurrentLevel = new Level("Level 2", "Уничтожить ядро защиты", 2, 4, new() { new EliminateAllEnemiesQuest() });
                break;
            default:
                CurrentLevel = new Level("Level 1", "Взломать защиту системы", 1, 3, new() { new EliminateAllEnemiesQuest() });
                break;
        }

        // Инициализируем врагов и карты для текущего уровня
        CurrentLevel.Enemies = EnemiesConst.FirsLevelEnemies;

        // Отображаем врагов на экране
        G.enemyManager.SetupEnemies(CurrentLevel.Enemies);
        G.ui.SetLevelUI(CurrentLevel);
        G.ui.SetPlayerUI(G.playerManager.Player);
        // G.gameStateManager.SetGameState(GameState.LevelSetup);  // Переход к подготовке уровня
    }

    // Завершение уровня
    public void CheckCompleteLevel()
    {
        CurrentLevel.CheckCompletion();
    }

    // Перезагрузка уровня
    public void RestartLevel()
    {
        LoadLevel(CurrentLevel.LevelNumber);
    }
}
