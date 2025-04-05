using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public TMP_Text cardNameText;
    private Card currentCard;

    private bool isDragging = false;

    private RectTransform rectTransform;
    private Vector3 originalPosition;
    private Camera mainCamera;
    private Collider2D cardCollider;
    private SpriteRenderer dropZoneSR;
    private Image image;

    private static Color activeColorZone = new Color(UtilsColor.ParseHex("858585").r, UtilsColor.ParseHex("858585").g, UtilsColor.ParseHex("858585").b, 0.1f);
    private static Color disabledColorZone = new Color(1f, 1f, 1f, 0f);

    private void Awake()
    {
        mainCamera = Camera.main;
        rectTransform = GetComponent<RectTransform>();
        cardCollider = GetComponent<Collider2D>();
        dropZoneSR = G.handManager.DropZone.GetComponent<SpriteRenderer>();
        image = GetComponent<Image>();
    }

    public void SetupCard(Card card)
    {
        currentCard = card;

        if (cardNameText != null)
            cardNameText.text = card.CardName;

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse entered on: " + currentCard.CardName);
        if (currentCard != null)
        {
            Debug.Log("Mouse entered on: " + currentCard.CardName);
            Tween.Scale(transform, new Vector3(1.1f, 1.1f, 1f), 0.2f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (currentCard != null)
        {
            Debug.Log("Mouse exited from: " + currentCard.CardName);
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
            dropZoneSR.color = disabledColorZone;
        }
        else
        {

            dropZoneSR.color = activeColorZone;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (G.gameStateManager.CurrentState != GameState.PlayerTurn) return;
        isDragging = false;


        if (IsDropZoneUnderMouse())
        {
            dropZoneSR.color = disabledColorZone;
            Debug.Log("Card dropped into DropArea: " + currentCard.CardName);
            currentCard.PlayCard(G.playerManager.Player, G.enemyManager.choiceEnemy);
            G.ui.console.PrintToConsoleNew(currentCard.ConsoleText);
            G.handManager.NewActiveCard(currentCard);
            G.handManager.RemoveCard(currentCard);
            G.gameStateManager.SetGameState(GameState.EnemyTurn);
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