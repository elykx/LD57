using System;
using System.Linq;
using PrimeTween;
using UnityEngine;

public class SkipButton : MonoBehaviour
{
    public void Skip()
    {
        if (G.gameStateManager.CurrentState != GameState.PlayerTurn) return;
        G.gameStateManager.SetGameState(GameState.EnemyTurn);
        G.levelManager.CurrentLevel.Energy++;
        Tween.LocalPositionY(gameObject.transform, -15f, 0.5f, Ease.InOutQuad, 1).OnComplete(() =>
            {
                Tween.LocalPositionY(gameObject.transform, 0f, 0.5f, Ease.InOutQuad);
            });
    }
}