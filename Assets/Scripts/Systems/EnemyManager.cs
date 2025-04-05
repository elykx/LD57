using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> Enemies;
    public GameObject EnemyPrefab;
    public Transform EnemyArea;
    public Enemy choiceEnemy;

    private void Awake()
    {
        G.enemyManager = this;
    }

    public void ChoiceEnemy(Enemy enemy)
    {
        choiceEnemy = enemy;
    }

    public void SetupEnemies(List<Enemy> enemies)
    {
        Enemies = enemies;
        choiceEnemy = enemies[0];
        DisplayEnemies();
    }

    public void RemoveEnemy(Enemy enemy)
    {
        Enemies.Remove(enemy);
        if (Enemies.Count != 0){
            choiceEnemy = Enemies[0];
        }
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
            if (enemy.Health <= 0)
            {
                Enemies.Remove(enemy);
            }
        }
        G.gameStateManager.SetGameState(GameState.PlayerTurn);  // Переход к следующему ходу игрока
    }
}
