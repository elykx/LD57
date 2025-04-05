using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text cardNameText;
    public TMP_Text costText;
    private Card currentCard;

    public void SetupCard(Card card)
    {
        currentCard = card;

        if (cardNameText != null)
            cardNameText.text = card.CardName;

        if (costText != null)
            costText.text = card.Cost.ToString();
    }

    // Этот метод вызывается при клике на карту
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Card clicked: " + currentCard.CardName);
        if (currentCard != null)
        {
            Debug.Log("Card clicked: " + currentCard.CardName);
            // Реализуйте логику использования карты
            currentCard.PlayCard(G.playerManager.Player, G.enemyManager.Enemies[0]);
            G.handManager.RemoveCard(); // Это нужно настроить
        }
    }

    // Этот метод вызывается при наведении на карту
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse entered on: " + currentCard.CardName);
        if (currentCard != null)
        {
            Debug.Log("Mouse entered on: " + currentCard.CardName);
            // Здесь можно добавить анимацию с использованием PrimeTween
            Tween.Scale(transform, new Vector3(1.1f, 1.1f, 1f), 0.2f);
        }
    }

    // Этот метод вызывается при убирании мыши с карты
    public void OnPointerExit(PointerEventData eventData)
    {
        if (currentCard != null)
        {
            Debug.Log("Mouse exited from: " + currentCard.CardName);
            // Здесь можно вернуть масштаб обратно
            Tween.Scale(transform, new Vector3(1f, 1f, 1f), 0.2f);
        }
    }
}