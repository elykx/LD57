using System;
using System.Linq;
using PrimeTween;
using UnityEngine;

public class CpuButton : MonoBehaviour
{
    public void TakeCard()
    {
        if (G.levelManager.CurrentLevel.Energy <= 0) return;
        if (G.gameStateManager.CurrentState != GameState.PlayerTurn) return;
        if (G.playerManager.Player.Hand.Count() >= 5) return;
        G.levelManager.CurrentLevel.Energy--;
        G.handManager.AddCardToHand(SessionData.Instance.GetRandomCardFromAvailableCards());
        Tween.LocalPositionY(gameObject.transform, -15f, 0.5f, Ease.InOutQuad, 1).OnComplete(() =>
            {
                Tween.LocalPositionY(gameObject.transform, 0f, 0.5f, Ease.InOutQuad);
            });
    }
}