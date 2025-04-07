using System.Linq;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player Player = new Player();

    private void Awake()
    {
        G.playerManager = this;
    }
}