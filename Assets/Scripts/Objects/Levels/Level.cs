using System.Collections.Generic;

public class Level
{
    public string LevelName;                // Название уровня
    public string LevelDescription;         // Описание цели уровня
    public int LevelNumber;                 // Номер уровня
    public int MaxEnemies;                  // Максимальное количество врагов на уровне
    public List<Enemy> Enemies;            // Список врагов на уровне
    public string Objective;               // Цель для завершения уровня
    public bool IsCompleted;               // Завершен ли уровень

    // Конструктор
    public Level(string levelName, string levelDescription, int levelNumber, int maxEnemies, string objective)
    {
        LevelName = levelName;
        LevelDescription = levelDescription;
        LevelNumber = levelNumber;
        MaxEnemies = maxEnemies;
        Objective = objective;
        Enemies = new List<Enemy>();
        IsCompleted = false;
    }

    // Инициализация врагов для уровня
    public void InitializeEnemies()
    {
        Enemies.Clear(); // Очистка предыдущих врагов
        for (int i = 0; i < 5; i++)
        {
            // Пример: создание случайных врагов для уровня
            Enemies.Add(new Malware("Malware " + (i + 1), 40, 8));
        }
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
