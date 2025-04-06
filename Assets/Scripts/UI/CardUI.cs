using System.Collections.Generic;
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
    private List<SpriteRenderer> enemyDropZones = new List<SpriteRenderer>();
    private List<SpriteRenderer> activeEnemyDropZones = new List<SpriteRenderer>();

    private Image image;

    private static Color activeColorZone = new Color(UtilsColor.ParseHex("858585").r, UtilsColor.ParseHex("858585").g, UtilsColor.ParseHex("858585").b, 0.1f);
    private static Color disabledColorZone = new Color(1f, 1f, 1f, 0f);

    private void Awake()
    {
        mainCamera = Camera.main;
        rectTransform = GetComponent<RectTransform>();
        cardCollider = GetComponent<Collider2D>();
        dropZoneSR = G.handManager.DropZone.GetComponent<SpriteRenderer>();
        foreach (GameObject zone in G.handManager.AttackDropZones)
        {
            enemyDropZones.Add(zone.GetComponent<SpriteRenderer>());
        }
        image = GetComponent<Image>();
    }

    public void SetupCard(Card card)
    {
        currentCard = card;

        if (cardNameText != null)
            cardNameText.text = card.CardName;

    }

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
        if (currentCard != null)
        {
            Tween.Scale(transform, new Vector3(1.1f, 1.1f, 1f), 0.2f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (currentCard != null)
        {
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

        if (currentCard is AttackCard attackCard)
        {
            for (int i = 0; i < G.handManager.AttackDropZones.Count; i++)
            {
                int index = i;
                if (G.enemyManager.Enemies.Exists(e => e.SpawnIndex == index))
                {
                    G.handManager.AttackDropZones[i].GetComponent<SpriteRenderer>().color = activeColorZone;
                }
            }
        }
        else
        {
            if (IsDropZoneUnderMouse())
            {
                dropZoneSR.color = disabledColorZone;
            }
            else
            {
                dropZoneSR.color = activeColorZone;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (G.gameStateManager.CurrentState != GameState.PlayerTurn) return;
        isDragging = false;

        if (currentCard is AttackCard attackCard)
        {
            for (int i = 0; i < G.handManager.AttackDropZones.Count; i++)
            {
                int index = i;
                if (G.enemyManager.Enemies.Exists(e => e.SpawnIndex == index))
                {
                    if (CheckDropZoneUnderMouse(G.handManager.AttackDropZones[i]))
                    {
                        G.handManager.AttackDropZones[i].GetComponent<SpriteRenderer>().color = disabledColorZone;
                        var choiceEnemy = G.enemyManager.Enemies.Find(e => e.SpawnIndex == index);
                        currentCard.PlayCard(G.playerManager.Player, choiceEnemy, G.levelManager.CurrentLevel);
                        G.ui.console.PrintToConsoleNew(currentCard.ConsoleText);
                        G.handManager.NewActiveCard(currentCard);
                        G.handManager.RemoveCard(currentCard);
                        G.gameStateManager.SetGameState(GameState.EnemyTurn);
                        Destroy(gameObject);
                    }
                    else
                    {
                        G.handManager.AttackDropZones[i].GetComponent<SpriteRenderer>().color = disabledColorZone;
                        Tween.Position(transform, originalPosition, 0.2f);
                    }
                }
            }
        }
        else
        {
            if (IsDropZoneUnderMouse())
            {
                dropZoneSR.color = disabledColorZone;
                currentCard.PlayCard(G.playerManager.Player, G.enemyManager.choiceEnemy, G.levelManager.CurrentLevel);
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
        }


        cardCollider.enabled = true;
    }

    private bool CheckDropZoneUnderMouse(GameObject zone)
    {
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, Vector2.zero);
        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag("DropZone"))
            {
                return hit.collider.gameObject == zone;
            }
        }

        return false;
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