using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public List<Card> PlayerHand;

    public GameObject CardPrefab; // Префаб карты
    public Transform HandArea; // Область для размещения карт
    private void Awake()
    {
        G.handManager = this;
    }

    public void SetupPlayerHand()
    {
        Debug.Log("Настроили руку игрока.");
        PlayerHand = new List<Card>
        {
            new AttackCard("Cyber Slash", 2, 10),
            new DefenseCard("Firewall", 3, 5),
            new ProgressCard("Data Harvest", 2, 15),
            // Добавьте другие карты, которые будут в руке игрока
        };

        DisplayCards();
    }

    public void RemoveCard()
    {
        // HandArea.RemoveCard(HandArea.currentCards[0]);
    }

    private void DisplayCards()
    {
        for (int i = 0; i < PlayerHand.Count; i++)
        {
            // Создание карты
            GameObject cardObject = Instantiate(CardPrefab, HandArea);
            cardObject.GetComponent<CardUI>().SetupCard(PlayerHand[i]);
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
