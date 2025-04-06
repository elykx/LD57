using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public string LevelName;
    public string LevelDescription;
    public int LevelNumber;
    public int MaxEnemies;
    public List<Enemy> Enemies;
    public List<ILevelQuest> Quests;
    public int ProgressQuest;
    public int ProgressCurrent;
    public bool IsCompleted;

    public Level(string levelName, string levelDescription, int levelNumber, int maxEnemies, List<ILevelQuest> quests, int progress)
    {
        LevelName = levelName;
        LevelDescription = levelDescription;
        LevelNumber = levelNumber;
        MaxEnemies = maxEnemies;
        Quests = quests;
        Enemies = new List<Enemy>();
        IsCompleted = false;
        ProgressQuest = progress;
        ProgressCurrent = 0;
    }

    public void CheckCompletion()
    {
        Debug.Log("check compete level" + "count " + Enemies.Count);
        if (Enemies.Count == 0)
        {
            IsCompleted = true;
        }
    }

    public void AddProgress(int progress)
    {
        ProgressCurrent += progress;
        if (ProgressCurrent >= ProgressQuest)
        {
            ProgressCurrent = ProgressQuest;
            IsCompleted = true;
        }
    }
}
