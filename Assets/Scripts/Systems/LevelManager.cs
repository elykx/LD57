using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Level CurrentLevel;
    public Dictionary<string, Func<Enemy>> AvailableEnemies = new();

    private void Awake()
    {
        G.levelManager = this;
        Debug.Log("Init Level Manager");
        Sprite[] enemySprites = Resources.LoadAll<Sprite>("Sprites/enemy");
        AvailableEnemies.Add("System Defender", () => new Malware("System Defender", 2, 1,
            "> !! anomaly detected !!\n" +
            "> unauthorized process detected: malware.exe\n" +
            "> initiating countermeasure...\n" +
            "> process flagged for termination\n" +
            "> counterattack incoming...\n",
            enemySprites.FirstOrDefault(s => s.name == "enemy_0"),
            "Name = System Defender\nHealth = 2\nDamage = 1\nA basic defense unit designed to protect systems by detecting and neutralizing unauthorized processes. Beware of counterattacks."));
        AvailableEnemies.Add("Antivirus", () => new Malware("Antivirus", 4, 1,
            "> !! anomaly detected !!\n" +
            "> unauthorized process detected: malware.exe\n" +
            "> activating antivirus scan...\n" +
            "> malware identified: quarantine triggered\n" +
            "> counteraction initiated...\n",
            enemySprites.FirstOrDefault(s => s.name == "enemy_6"),
             "Name = Antivirus\nHealth = 4\nDamage = 1\nA sophisticated antivirus program that actively hunts for and neutralizes malware. It can quarantine and disrupt your actions."));
        AvailableEnemies.Add("AI Defense", () => new Malware("AI Defense", 3, 2,
            "> !! anomaly detected !!\n" +
            "> unauthorized process detected: malware.exe\n" +
            "> AI defense protocols activated...\n" +
            "> analyzing threat...\n" +
            "> initiating lockdown...\n",
        enemySprites.FirstOrDefault(s => s.name == "enemy_3"),
            "Name = AI Defense\nHealth = 3\nDamage = 2\nAn AI system designed to detect and neutralize unauthorized processes. It can analyze threats and initiate a lockdown."));
        AvailableEnemies.Add("Security Protocol", () => new SystemDefender("Security Protocol", 4, 1, 1,
            "> !! anomaly detected !!\n" +
            "> unauthorized process detected: malware.exe\n" +
            "> initiating countermeasure...\n" +
            "> rerouting protocols...\n" +
            "> process terminated successfully\n",
          enemySprites.FirstOrDefault(s => s.name == "enemy_7"),
            "Name = Security Protocol\nHealth = 4\nDamage = 1\nDefense = 1\nA system designed to detect and neutralize unauthorized processes. It can reroute protocols and protect against counterattacks."));
        AvailableEnemies.Add("Cloud Node", () => new SystemDefender("Cloud Node", 6, 1, 2,
            "> !! anomaly detected !!\n" +
            "> unauthorized process detected: malware.exe\n" +
            "> cloud defense initiated...\n" +
            "> scanning for threats...\n" +
            "> quarantining node...\n",
        enemySprites.FirstOrDefault(s => s.name == "enemy_8"),
            "Name = Cloud Node\nHealth = 6\nDamage = 1\nDefense = 2\nA cloud-based system designed to detect and neutralize unauthorized processes. It can scan for threats and quarantine nodes."));
        AvailableEnemies.Add("Backup System", () => new SystemDefender("Backup System", 5, 2, 1,
            "> !! anomaly detected !!\n" +
            "> unauthorized process detected: malware.exe\n" +
            "> initiating backup defense...\n" +
            "> restoring secure state...\n" +
            "> process shutdown completed\n",
        enemySprites.FirstOrDefault(s => s.name == "enemy_9"),
        "Name = Backup System\nHealth = 5\nDamage = 2\nDefense = 1\nA backup defense system that restores secure states and terminates malicious processes to ensure stability."));
    }

    public void LoadLevel(int levelNumber)
    {
        Debug.Log("LoadLevel called with: " + levelNumber);


        switch (levelNumber)
        {
            case 1:
                CurrentLevel = new Level("Level", "Взломать защиту системы", 1, 2, new() { new EliminateAllEnemiesQuest() }, 10, 5, 2);
                CurrentLevel.Enemies.Add(AvailableEnemies["System Defender"]());
                CurrentLevel.Enemies.Add(AvailableEnemies["System Defender"]());
                Debug.Log("Enemies Count: " + CurrentLevel.Enemies.Count);
                break;
            case 2:
                CurrentLevel = new Level("Level 2", "Уничтожить ядро защиты", 2, 4, new() { new EliminateAllEnemiesQuest() }, 15, 6, 3);
                CurrentLevel.Enemies.Add(AvailableEnemies["Antivirus"]());
                CurrentLevel.Enemies.Add(AvailableEnemies["System Defender"]());
                break;
            case 3:
                CurrentLevel = new Level("Level 3", "Уничтожить ядро защиты", 2, 4, new() { new EliminateAllEnemiesQuest() }, 20, 10, 3);
                CurrentLevel.Enemies.Add(AvailableEnemies["Antivirus"]());
                CurrentLevel.Enemies.Add(AvailableEnemies["Antivirus"]());
                CurrentLevel.Enemies.Add(AvailableEnemies["AI Defense"]());
                break;
            case 4:
                CurrentLevel = new Level("Level 4", "Уничтожить ядро защиты", 2, 4, new() { new EliminateAllEnemiesQuest() }, 21, 12, 4);
                CurrentLevel.Enemies.Add(AvailableEnemies["Cloud Node"]());
                CurrentLevel.Enemies.Add(AvailableEnemies["AI Defense"]());
                CurrentLevel.Enemies.Add(AvailableEnemies["Antivirus"]());
                CurrentLevel.Enemies.Add(AvailableEnemies["System Defender"]());
                break;
            case 5:
                CurrentLevel = new Level("Level 5", "Уничтожить ядро защиты", 2, 4, new() { new EliminateAllEnemiesQuest() }, 24, 15, 4);
                CurrentLevel.Enemies.Add(AvailableEnemies["Cloud Node"]());
                CurrentLevel.Enemies.Add(AvailableEnemies["Antivirus"]());
                CurrentLevel.Enemies.Add(AvailableEnemies["System Defender"]());
                break;
            case 6:
                CurrentLevel = new Level("Level 6", "Уничтожить ядро защиты", 2, 4, new() { new EliminateAllEnemiesQuest() }, 28, 18, 5);
                CurrentLevel.Enemies.Add(AvailableEnemies["Backup System"]());
                CurrentLevel.Enemies.Add(AvailableEnemies["AI Defense"]());
                CurrentLevel.Enemies.Add(AvailableEnemies["Security Protocol"]());
                break;
            case 7:
                CurrentLevel = new Level("Level 7", "Уничтожить ядро защиты", 2, 4, new() { new EliminateAllEnemiesQuest() }, 30, 20, 5);
                CurrentLevel.Enemies.Add(AvailableEnemies["Backup System"]());
                CurrentLevel.Enemies.Add(AvailableEnemies["Cloud Node"]());
                CurrentLevel.Enemies.Add(AvailableEnemies["Security Protocol"]());
                CurrentLevel.Enemies.Add(AvailableEnemies["AI Defense"]());
                break;
            default:
                SceneManager.LoadScene("Menu");
                break;
        }

        G.enemyManager.SetupEnemies(CurrentLevel.Enemies);
    }

    public void CheckCompleteLevel()
    {
        Debug.Log("check complete level");
        CurrentLevel.CheckCompletion();
        if (G.levelManager.CurrentLevel.IsCompleted)
            G.gameStateManager.SetGameState(GameState.LevelComplete);

    }

    public void CheckEnergy()
    {
        if (G.levelManager.CurrentLevel.Energy <= 0)
        {
            G.gameStateManager.SetGameState(GameState.EnemyTurn);
            G.levelManager.CurrentLevel.Energy++;
        }

    }

    public void RestartLevel()
    {
        LoadLevel(CurrentLevel.LevelNumber);
    }
}
