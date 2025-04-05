using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public TMP_Text cardNameText;
    public TMP_Text costText;

    private Card currentCard;

    private bool isDragging = false;

    private RectTransform rectTransform;
    private Vector3 originalPosition;
    private Camera mainCamera;
    private Collider2D cardCollider;
    private SpriteRenderer dropZoneSR;

    private void Awake()
    {
        mainCamera = Camera.main;
        rectTransform = GetComponent<RectTransform>();
        cardCollider = GetComponent<Collider2D>();
        dropZoneSR = G.handManager.DropZone.GetComponent<SpriteRenderer>();
    }

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
        if (currentCard != null)
        {
            Debug.Log("Card clicked: " + currentCard.CardName);
            // // Реализуйте логику использования карты
            // currentCard.PlayCard(G.playerManager.Player, G.enemyManager.Enemies[0]);
            // G.handManager.RemoveCard(); // Это нужно настроить
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

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (G.gameStateManager.CurrentState != GameState.PlayerTurn) return;
        originalPosition = rectTransform.position;
        isDragging = true;
        cardCollider.enabled = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging) return;
        if (G.gameStateManager.CurrentState != GameState.PlayerTurn) return;
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        transform.position = worldPos;

        if (IsDropZoneUnderMouse())
        {
            dropZoneSR.color = UtilsColor.ParseHex("FFFFFF");
        }
        else
        {
            dropZoneSR.color = UtilsColor.ParseHex("858585");
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (G.gameStateManager.CurrentState != GameState.PlayerTurn) return;
        isDragging = false;


        if (IsDropZoneUnderMouse())
        {
            dropZoneSR.color = UtilsColor.ParseHex("858585");
            Debug.Log("Card dropped into DropArea: " + currentCard.CardName);
            currentCard.PlayCard(G.playerManager.Player, G.enemyManager.choiceEnemy);
            G.handManager.RemoveCard(currentCard);
            Destroy(gameObject);
        }
        else
        {
            Tween.Position(transform, originalPosition, 0.2f);
        }

        cardCollider.enabled = true;

    }

    private bool IsDropZoneUnderMouse()
    {
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null)
        {
            return hit.collider.gameObject == G.handManager.DropZone;
        }

        return false;
    }
}