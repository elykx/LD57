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

    private void Start()
    {
        SetGameState(GameState.MainMenu);  // Начинаем с главного меню
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
                G.levelManager.LoadLevel(CurrentLevelNumber);  // Загружаем уровень
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
        // Игрок начинает ход
        // Отображаем карты игрока, начинаем принимать ввод
    }

    private void StartEnemyTurn()
    {
        // Ход врагов
        // Враги выполняют свои действия
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
}
