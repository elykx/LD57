
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TMP_Text playerHealthText;

    public void SetPlayer(Player player)
    {
        if (player != null)
        {
            playerHealthText.text = $"{player.Health} / {player.MaxHealth}";
        }
    }
}