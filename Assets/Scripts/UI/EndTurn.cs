using UnityEngine;

public class EndTurn : MonoBehaviour
{
    public void EndPlayerTurn()
    {
        if (G.gameStateManager.CurrentState != GameState.PlayerTurn) return;
        G.gameStateManager.SetGameState(GameState.EnemyTurn);
    }
}