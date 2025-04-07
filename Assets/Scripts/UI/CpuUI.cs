using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CpuUI : MonoBehaviour
{
    public Image cpuImage;
    public TMP_Text cpuText;

    private TooltipTrigger tooltipTrigger;

    void Awake()
    {
        tooltipTrigger = GetComponent<TooltipTrigger>();
    }

    void Update()
    {
        cpuText.text = "CPU: " + G.levelManager.CurrentLevel.Energy + "/" + G.levelManager.CurrentLevel.MaxEnergy;

        float ratio = (float)G.levelManager.CurrentLevel.Energy / G.levelManager.CurrentLevel.MaxEnergy;
        cpuImage.fillAmount = Mathf.Clamp01(ratio);

        tooltipTrigger.tooltipContent = $"It is needed to play cards and get new ones: <color=#D76B00>{G.levelManager.CurrentLevel.Energy} / {G.levelManager.CurrentLevel.MaxEnergy}</color>";

    }
}