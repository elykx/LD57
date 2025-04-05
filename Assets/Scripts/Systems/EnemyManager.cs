using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> Enemies;
    public GameObject EnemyPrefab;
    public Transform EnemyArea;
    public Enemy choiceEnemy;
    private List<Enemy> toRemove = new List<Enemy>();

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
        Debug.Log("SetupEnemies" + enemies.Count);
        Enemies = enemies;
        choiceEnemy = enemies[0];
        DisplayEnemies();
    }

    public void RemoveEnemy(Enemy enemy)
    {
        toRemove.Add(enemy);
    }

    private void DisplayEnemies()
    {
        foreach (Enemy enemy in Enemies)
        {
            GameObject enemyObject = Instantiate(EnemyPrefab, EnemyArea);
            enemyObject.GetComponent<EnemyUI>().SetupEnemy(enemy);
        }
    }

    public void RemoveEnemies()
    {
        foreach (Enemy enemy in toRemove)
        {
            Enemies.Remove(enemy);
        }
        if (Enemies.Count != 0 && !Enemies.Exists(e => e == choiceEnemy))
        {
            choiceEnemy = Enemies[0];
        }
    }

    public void StartEnemyTurn()
    {
        StartCoroutine(EnemyActionsRoutine());
    }

    private IEnumerator EnemyActionsRoutine()
    {
        yield return new WaitForSeconds(3f);
        foreach (Enemy enemy in Enemies)
        {
            if (enemy.Health <= 0) continue;

            enemy.PerformAction(G.playerManager.Player);
            G.ui.console.PrintToConsoleAdd(enemy.ConsoleText);

            yield return new WaitForSeconds(2.5f);
        }

        yield return new WaitForSeconds(0.5f);
        G.gameStateManager.SetGameState(GameState.PlayerTurn);
    }


}
