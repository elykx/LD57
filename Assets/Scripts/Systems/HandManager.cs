using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public GameObject CardPrefab; // Префаб карты
    public Transform HandArea; // Область для размещения карт
    public GameObject DropZone;
    private void Awake()
    {
        G.handManager = this;
    }

    public void SetupPlayerHand()
    {
        var needCard = 3 - G.playerManager.Player.Hand.Count();
        for (int i = 0; i < needCard; i++)
        {
            G.playerManager.Player.Hand.Add(G.playerManager.Player.GetRandomCardFromAvailableCards());
        }

        DisplayCards();
    }

    public void RemoveCard(Card card)
    {
        G.playerManager.Player.Hand.Remove(card);
    }

    private void DisplayCards()
    {
        for (int i = 0; i < G.playerManager.Player.Hand.Count; i++)
        {
            // Создание карты
            GameObject cardObject = Instantiate(CardPrefab, HandArea);
            cardObject.GetComponent<CardUI>().SetupCard(G.playerManager.Player.Hand[i]);
        }
    }

    public void PlayCard(Card card)
    {
        // Реализуйте логику использования карты
        Debug.Log($"Карта {card.CardName} использована.");
        // card.PlayCard(PlayerManager.Instance.Player, EnemyManager.Instance.Enemies[0]);

        // Перезагрузить или обновить карты
        // HandArea.RemoveCard(card);
    }
}
