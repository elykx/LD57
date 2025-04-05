using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> Enemies;
    public GameObject EnemyPrefab;
    public Transform EnemyArea;

    private void Awake()
    {
        G.enemyManager = this;
    }

    public void SetupEnemies(List<Enemy> enemies)
    {
        Enemies = enemies;
        DisplayEnemies();
    }

    private void DisplayEnemies()
    {
        foreach (Enemy enemy in Enemies)
        {
            GameObject enemyObject = Instantiate(EnemyPrefab, EnemyArea);
            enemyObject.GetComponent<EnemyUI>().SetupEnemy(enemy);  // Пример того, как связать UI с врагом
        }
    }


    public void StartEnemyTurn()
    {
        foreach (Enemy enemy in Enemies)
        {
            enemy.PerformAction(G.playerManager.Player);
        }
        G.gameStateManager.SetGameState(GameState.PlayerTurn);  // Переход к следующему ходу игрока
    }
}
