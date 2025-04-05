using System.Collections.Generic;

public class Level
{
    public string LevelName;                // Название уровня
    public string LevelDescription;         // Описание цели уровня
    public int LevelNumber;                 // Номер уровня
    public int MaxEnemies;                  // Максимальное количество врагов на уровне
    public List<Enemy> Enemies;            // Список врагов на уровне
    public List<ILevelQuest> Quests;               // Цель для завершения уровня
    public bool IsCompleted;               // Завершен ли уровень

    // Конструктор
    public Level(string levelName, string levelDescription, int levelNumber, int maxEnemies, List<ILevelQuest> quests)
    {
        LevelName = levelName;
        LevelDescription = levelDescription;
        LevelNumber = levelNumber;
        MaxEnemies = maxEnemies;
        Quests = quests;
        Enemies = new List<Enemy>();
        IsCompleted = false;
    }

    // Проверка на завершение уровня
    public void CheckCompletion()
    {
        if (Enemies.Count == 0)
        {
            IsCompleted = true;
            G.gameStateManager.SetGameState(GameState.LevelComplete);  // Переход к завершению уровня
        }
    }
}
