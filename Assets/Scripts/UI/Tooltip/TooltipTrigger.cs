// TooltipTrigger.cs - скрипт, который добавляется на объекты, требующие тултип
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string tooltipTitle;
    public string tooltipContent;

    private bool isMouseOver = false;

    // Для объектов с коллайдерами
    private void OnMouseEnter()
    {
        if (!EventSystem.current.IsPointerOverGameObject())  // Игнорировать, если курсор над UI
        {
            isMouseOver = true;
            ShowTooltip();
        }
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
        HideTooltip();
    }

    // Для UI элементов
    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
        ShowTooltip();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
        HideTooltip();
    }

    private void ShowTooltip()
    {
        if (TooltipManager.Instance != null)
        {
            TooltipManager.Instance.ShowTooltip(tooltipTitle, tooltipContent);
        }
    }

    private void HideTooltip()
    {
        if (TooltipManager.Instance != null)
        {
            TooltipManager.Instance.HideTooltip();
        }
    }

    // Скрывать тултип при деактивации объекта
    private void OnDisable()
    {
        if (isMouseOver && TooltipManager.Instance != null)
        {
            TooltipManager.Instance.HideTooltip();
            isMouseOver = false;
        }
    }
}