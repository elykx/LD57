using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public LevelUI levelUI;
    public PlayerUI playerUI;
    public TMP_Text gameState;
    private void Awake()
    {
        G.ui = this;
    }

    public void SetLevelUI(Level level)
    {
        levelUI.SetLevel(level);
    }

    public void SetPlayerUI(Player player)
    {
        playerUI.SetPlayer(player);
    }

    void Update()
    {
        gameState.text = G.gameStateManager.CurrentState.ToString() + "\n" + G.enemyManager.Enemies.Count;
    }

}