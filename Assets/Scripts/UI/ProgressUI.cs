using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressUI : MonoBehaviour
{
    public Image progressImage;
    public TMP_Text progressText;

    void Update()
    {
        // Обновляем текст
        progressText.text = "Progress: " + G.levelManager.CurrentLevel.ProgressCurrent + "/" + G.levelManager.CurrentLevel.ProgressQuest;

        // Вычисляем и обновляем заполнение линии прогресса
        float progressRatio = (float)G.levelManager.CurrentLevel.ProgressCurrent / G.levelManager.CurrentLevel.ProgressQuest;
        progressImage.fillAmount = Mathf.Clamp01(progressRatio); // Ограничиваем значение от 0 до 1
    }
}