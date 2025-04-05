using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public Level CurrentLevel;             // Текущий уровень

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
                CurrentLevel = new Level("Level 1", "Взломать защиту системы", 1, 3, "Очистить систему от Malware.");
                break;
            case 2:
                CurrentLevel = new Level("Level 2", "Уничтожить ядро защиты", 2, 4, "Найти и уничтожить ядро защиты.");
                break;
            default:
                CurrentLevel = new Level("Level 1", "Взломать защиту системы", 1, 3, "Очистить систему от Malware.");
                break;
        }

        // Инициализируем врагов и карты для текущего уровня
        CurrentLevel.InitializeEnemies();

        // Отображаем врагов на экране
        G.enemyManager.SetupEnemies(CurrentLevel.Enemies);
        G.ui.SetLevelUI(CurrentLevel);
        G.gameStateManager.SetGameState(GameState.LevelSetup);  // Переход к подготовке уровня
    }

    // Завершение уровня
    public void CompleteLevel()
    {
        CurrentLevel.CheckCompletion();
    }

    // Перезагрузка уровня
    public void RestartLevel()
    {
        LoadLevel(CurrentLevel.LevelNumber);
    }
}
