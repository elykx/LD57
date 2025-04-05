using System.Collections.Generic;

public class Level
{
    public string LevelName;
    public string LevelDescription;
    public int LevelNumber;
    public int MaxEnemies;
    public List<Enemy> Enemies;
    public List<ILevelQuest> Quests;
    public bool IsCompleted;

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

    public void CheckCompletion()
    {
        if (Enemies.Count == 0)
        {
            IsCompleted = true;
            G.gameStateManager.SetGameState(GameState.LevelComplete);  // Переход к завершению уровня
        }
    }
}
