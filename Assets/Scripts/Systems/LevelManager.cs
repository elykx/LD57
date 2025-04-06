using System.Linq;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Level CurrentLevel;

    private void Awake()
    {
        G.levelManager = this;
        Debug.Log("Init Level Manager");
    }

    public void LoadLevel(int levelNumber)
    {
        Debug.Log("LoadLevel called with: " + levelNumber);
        Sprite[] enemySprites = Resources.LoadAll<Sprite>("Sprites/enemy");


        switch (levelNumber)
        {
            case 1:
                CurrentLevel = new Level("Level 1 bla-bla-bla", "Взломать защиту системы", 1, 3, new() { new EliminateAllEnemiesQuest() }, 10);
                CurrentLevel.Enemies.Add(
                     new Malware("Malware 1", 10, 8,
                        "> !! anomaly detected !!\n" +
                        "> unauthorized process started: malware.exe\n" +
                        "> injecting code into stack...\n" +
                        "> process is running\n", enemySprites.FirstOrDefault(s => s.name == "enemy_0"))
                );
                CurrentLevel.Enemies.Add(
                     new Malware("Malware 2", 10, 8,
                        "> !! anomaly detected !!\n" +
                        "> unauthorized process started: malware.exe\n" +
                        "> injecting code into stack...\n" +
                        "> process is running\n", enemySprites.FirstOrDefault(s => s.name == "enemy_0"))
                );
                Debug.Log("Enemies Count: " + CurrentLevel.Enemies.Count);
                break;
            case 2:
                CurrentLevel = new Level("Level 2", "Уничтожить ядро защиты", 2, 4, new() { new EliminateAllEnemiesQuest() }, 15);
                CurrentLevel.Enemies.Add(
                    new Malware("Malware 1", 1, 8,
                       "> !! anomaly detected !!\n" +
                       "> unauthorized process started: malware.exe\n" +
                       "> injecting code into stack...\n" +
                       "> process is running\n", Resources.Load<Sprite>("/Sprites/enemy_0"))
               );
                CurrentLevel.Enemies.Add(
                     new Malware("Malware 2", 1, 8,
                        "> !! anomaly detected !!\n" +
                        "> unauthorized process started: malware.exe\n" +
                        "> injecting code into stack...\n" +
                        "> process is running\n", Resources.Load<Sprite>("/Sprites/enemy_0"))
                );
                break;
            default:
                SceneManager.LoadScene("Menu");
                break;
        }

        G.enemyManager.SetupEnemies(CurrentLevel.Enemies);
        G.ui.SetLevelUI(CurrentLevel);
        G.ui.SetPlayerUI(G.playerManager.Player);
    }

    public void CheckCompleteLevel()
    {
        Debug.Log("check complete level");
        CurrentLevel.CheckCompletion();
        if (G.levelManager.CurrentLevel.IsCompleted)
            G.gameStateManager.SetGameState(GameState.LevelComplete);

    }

    public void RestartLevel()
    {
        LoadLevel(CurrentLevel.LevelNumber);
    }
}
