using System.Collections;
using System.Linq;
using UnityEngine;

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
    public int CurrentLevelNumber = 1;     // Текущий уровень


    private void Awake()
    {
        G.gameStateManager = this;
    }

    public void SetGameState(GameState newState)
    {
        CurrentState = newState;

        // В зависимости от состояния запускаем нужные действия
        switch (newState)
        {
            case GameState.MainMenu:
                // ShowMainMenu();  // Показать главное меню
                break;

            case GameState.LevelSetup:
                StartCoroutine(DelayAction());
                G.levelManager.LoadLevel(CurrentLevelNumber);  // Загружаем уровень
                G.gameStateManager.SetGameState(GameState.PlayerTurn);
                break;

            case GameState.PlayerTurn:
                StartPlayerTurn();
                break;

            case GameState.EnemyTurn:
                StartEnemyTurn();
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
        G.levelManager.CheckCompleteLevel();
        if (G.playerManager.Player.Health <= 0)
        {
            SetGameState(GameState.GameOver);
            return;
        }
        if (G.levelManager.CurrentLevel.IsCompleted)
        {
            SetGameState(GameState.LevelComplete);
            return;
        }
        if (G.playerManager.Player.Hand.Count() < 3)
        {
            G.handManager.SetupPlayerHand();
        }
    }

    private void StartEnemyTurn()
    {
        Debug.Log("Enemy turn started.");

        // Здесь враги ходят — можно сделать корутину для задержек
        StartCoroutine(EnemyActionsRoutine());
    }

    private void CompleteLevel()
    {
        // Завершение уровня
        // Показать победу, статистику и перейти к следующему уровню или завершить игру
    }

    private void EndGame()
    {
        // Завершаем игру
        // Показываем экран Game Over
    }

    private IEnumerator EnemyActionsRoutine()
    {
        foreach (var enemy in G.enemyManager.Enemies)
        {
            Debug.Log(enemy);
            if (enemy.Health <= 0) continue;

            enemy.PerformAction(G.playerManager.Player); // Атака или действие

            yield return new WaitForSeconds(0.5f); // Пауза между действиями
        }

        yield return new WaitForSeconds(0.5f); // Пауза перед передачей хода
        SetGameState(GameState.PlayerTurn);
    }

    IEnumerator DelayAction()
    {
        // Задержка в 5 секунд
        yield return new WaitForSeconds(5f);

        // Действие после задержки
        Debug.Log("5 секунд прошло!");
    }
}
