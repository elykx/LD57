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
    public int Energy;
    public int MaxEnergy;
    public int CardInHand;
    public bool IsCompleted;

    public Level(string levelName, string levelDescription, int levelNumber, int maxEnemies, List<ILevelQuest> quests, int progress, int energy,
        int cardInHand)
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
        Energy = energy;
        MaxEnergy = energy;
        CardInHand = cardInHand;
    }

    public void CheckCompletion()
    {
        if (ProgressCurrent >= ProgressQuest)
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

    public void MinusEnergy(int energy)
    {
        Energy -= energy;
        if (Energy <= 0)
        {
            Energy = 0;
        }
    }
}
