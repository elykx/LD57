using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> Enemies;
    public GameObject EnemyPrefab;
    public List<Transform> SpawnPoints;
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
        // Перемешиваем позиции
        List<Transform> availablePoints = new List<Transform>(SpawnPoints);
        Shuffle.ShuffleList(availablePoints);

        for (int i = 0; i < Enemies.Count; i++)
        {
            Transform spawnPoint = availablePoints[i];
            GameObject enemyObject = Instantiate(EnemyPrefab, spawnPoint.position, Quaternion.identity);

            EnemyUI enemyUI = enemyObject.GetComponent<EnemyUI>();
            enemyUI.SetupEnemy(Enemies[i]);

            // Сохраняем позицию (если надо использовать для порядка хода)
            Enemies[i].SpawnIndex = SpawnPoints.IndexOf(spawnPoint);
        }

        // Можно отсортировать список врагов по SpawnIndex, если порядок хода важен:
        Enemies.Sort((a, b) => a.SpawnIndex.CompareTo(b.SpawnIndex));
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
        if (Enemies.Count == 0)
        {
            var enemyFactories = G.levelManager.AvailableEnemies.Values.ToList();

            SetupEnemies(Enumerable.Range(0, 2)
            .Select(_ =>
            {
                var randomIndex = Random.Range(0, enemyFactories.Count);
                return enemyFactories[randomIndex](); // вызов Func<Enemy>
            })
            .ToList());
        }
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
