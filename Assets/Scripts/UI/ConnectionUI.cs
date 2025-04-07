using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionUI : MonoBehaviour
{
    public Image connectionImage;
    public TMP_Text connectionText;
    private TooltipTrigger tooltipTrigger;

    void Awake()
    {
        tooltipTrigger = GetComponent<TooltipTrigger>();
    }

    void Update()
    {
        connectionText.text = G.playerManager.Player.Health + "\n" + "--" + "\n" + G.playerManager.Player.MaxHealth;

        float ratio = (float)G.playerManager.Player.Health / G.playerManager.Player.MaxHealth;
        connectionImage.fillAmount = Mathf.Clamp01(ratio);

        tooltipTrigger.tooltipContent = $"Connection displays the security of the connection: <color=#C57E7E>{G.playerManager.Player.Health} / {G.playerManager.Player.MaxHealth}</color>";

    }
}