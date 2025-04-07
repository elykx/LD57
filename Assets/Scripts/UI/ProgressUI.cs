using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressUI : MonoBehaviour
{
    public Image progressImage;
    public TMP_Text progressText;
    private TooltipTrigger tooltipTrigger;

    void Awake()
    {
        tooltipTrigger = GetComponent<TooltipTrigger>();
    }

    void Update()
    {
        progressText.text = "Progress: " + G.levelManager.CurrentLevel.ProgressCurrent + "/" + G.levelManager.CurrentLevel.ProgressQuest;

        float progressRatio = (float)G.levelManager.CurrentLevel.ProgressCurrent / G.levelManager.CurrentLevel.ProgressQuest;
        progressImage.fillAmount = Mathf.Clamp01(progressRatio);

        tooltipTrigger.tooltipContent = $"The amount of data to download: <color=#37802C>{G.levelManager.CurrentLevel.ProgressCurrent} / {G.levelManager.CurrentLevel.ProgressQuest}</color>";
    }
}