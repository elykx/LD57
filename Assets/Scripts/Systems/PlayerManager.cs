using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public Player Player;

    private void Awake()
    {
        G.playerManager = this;
    }

    public void SetupPlayerHand()
    {
        G.handManager.SetupPlayerHand();
    }
}