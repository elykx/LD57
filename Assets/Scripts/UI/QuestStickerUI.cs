using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuestStickerUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text questText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Tween.Scale(transform, new Vector3(1.1f, 1.1f, 1f), 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tween.Scale(transform, new Vector3(1f, 1f, 1f), 0.2f);
    }

    public void SetQuest(string text)
    {
        questText.text = text;
    }
}