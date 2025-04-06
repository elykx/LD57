using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    MainMenu,
    LevelSetup,
    PlayerTurn,
    EnemyTurn,
    LevelComplete,
    GameOver
}

public class GameStateManager : MonoBehaviour
{
    public GameState CurrentState;
    public int CurrentLevelNumber = 1;


    private void Awake()
    {
        G.gameStateManager = this;
        Debug.Log("Init Game State Manager");
    }

    public void SetGameState(GameState newState)
    {
        CurrentState = newState;
        switch (newState)
        {
            case GameState.MainMenu:
                // ShowMainMenu();  // Показать главное меню
                break;

            case GameState.LevelSetup:
                StartCoroutine(DelayAction());
                G.levelManager.LoadLevel(CurrentLevelNumber);
                G.gameStateManager.SetGameState(GameState.PlayerTurn);
                break;

            case GameState.PlayerTurn:
                StartPlayerTurn();
                G.enemyManager.RemoveEnemies();
                G.levelManager.CheckCompleteLevel();
                break;

            case GameState.EnemyTurn:
                G.enemyManager.StartEnemyTurn();
                break;

            case GameState.LevelComplete:
                CompleteLevel();
                break;

            case GameState.GameOver:
                EndGame();
                break;
        }
    }

    private void StartPlayerTurn()
    {
        if (G.playerManager.Player.Health <= 0)
        {
            SetGameState(GameState.GameOver);
            return;
        }
        if (G.playerManager.Player.Hand.Count() < 3)
        {
            G.handManager.SetupPlayerHand();
        }
    }

    private void CompleteLevel()
    {
        CurrentLevelNumber++;
        SetGameState(GameState.LevelSetup);
    }

    private void EndGame()
    {
        SceneManager.LoadScene("Menu");
    }

    IEnumerator DelayAction()
    {
        // Задержка в 5 секунд
        yield return new WaitForSeconds(5f);

        // Действие после задержки
        Debug.Log("5 секунд прошло!");
    }
}
