using UnityEngine;

public class Main : MonoBehaviour
{
    private void Awake()
    {
        G.main = this;
    }

    private void Start()
    {
        Debug.Log("Игра запущена.");
        G.gameStateManager.SetGameState(GameState.LevelSetup);
    }
}
