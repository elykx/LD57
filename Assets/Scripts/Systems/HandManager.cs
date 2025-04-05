using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public GameObject CyberSlashCard;
    public GameObject FirewallCard;
    public GameObject DataHarvest;
    public Transform HandArea;
    public GameObject DropZone;
    public Transform activeArea;
    public ActiveCardUI activeCardUI;
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
            var card = G.playerManager.Player.Hand[i];
            SpawnCardUi(card, HandArea);
        }

    }

    public void NewActiveCard(Card card)
    {
        SpawnActiveCardUi(card, activeArea);
    }

    public void RemoveCard(Card card)
    {
        G.playerManager.Player.Hand.Remove(card);
    }

    public void PlayCard(Card card)
    {
        Debug.Log($"Карта {card.CardName} использована.");
        // card.PlayCard(PlayerManager.Instance.Player, EnemyManager.Instance.Enemies[0]);

        // Перезагрузить или обновить карты
        // HandArea.RemoveCard(card);
    }

    public void SpawnCardUi(Card card, Transform parent)
    {
        if (card == AttackCardsLibrary.CyberSlash)
        {
            GameObject cardObject = Instantiate(CyberSlashCard, parent);
            cardObject.GetComponent<CardUI>().SetupCard(card);
        }
        else if (card == DefenseCardsLibrary.Firewall)
        {
            GameObject cardObject = Instantiate(FirewallCard, parent);
            cardObject.GetComponent<CardUI>().SetupCard(card);
        }
        else if (card == ProgressCardLibrary.DataHarvest)
        {
            GameObject cardObject = Instantiate(DataHarvest, parent);
            cardObject.GetComponent<CardUI>().SetupCard(card);
        }
    }

    public void SpawnActiveCardUi(Card card, Transform parent)
    {
        if (card == AttackCardsLibrary.CyberSlash)
        {
            GameObject cardObject = Instantiate(CyberSlashCard, parent);
            var cardUI = cardObject.GetComponent<CardUI>();
            Destroy(cardUI);
            activeCardUI = cardObject.AddComponent<ActiveCardUI>();
            activeCardUI.SetupCard(card);
            cardObject.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;

        }
        else if (card == DefenseCardsLibrary.Firewall)
        {
            GameObject cardObject = Instantiate(FirewallCard, parent);
            var cardUI = cardObject.GetComponent<CardUI>();
            Destroy(cardUI);
            activeCardUI = cardObject.AddComponent<ActiveCardUI>();
            activeCardUI.SetupCard(card);
            cardObject.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
        }
        else if (card == ProgressCardLibrary.DataHarvest)
        {
            GameObject cardObject = Instantiate(DataHarvest, parent);
            var cardUI = cardObject.GetComponent<CardUI>();
            Destroy(cardUI);
            activeCardUI = cardObject.AddComponent<ActiveCardUI>();
            activeCardUI.SetupCard(card);
            cardObject.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
        }
    }
}
