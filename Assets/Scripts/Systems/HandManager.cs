using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public GameObject ActiveCard;
    public GameObject CardBase;
    public Transform HandArea;
    public GameObject DropZone;
    public List<GameObject> AttackDropZones;
    public Transform activeArea;
    private GameObject activeCard;
    public AudioSource audioSourceCarthridge;
    private void Awake()
    {
        G.handManager = this;
    }

    public void SetupPlayerHand()
    {
        var needCard = G.levelManager.CurrentLevel.CardInHand - G.playerManager.Player.Hand.Count();
        for (int i = 0; i < needCard; i++)
        {
            G.playerManager.Player.Hand.Add(SessionData.Instance.GetRandomCardFromAvailableCards());
            var card = G.playerManager.Player.Hand[i];
            SpawnCardUi(card, HandArea);
        }
    }

    public void AddCardToHand(Card card)
    {
        if (G.playerManager.Player.Hand.Count() >= 5) return;
        G.playerManager.Player.Hand.Add(card);
        SpawnCardUi(card, HandArea);
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
        GameObject cardObject = Instantiate(CardBase, parent);
        cardObject.GetComponent<CardUI>().SetupCard(card);
    }

    public void SpawnActiveCardUi(Card card, Transform parent)
    {
        Destroy(activeCard);
        activeCard = Instantiate(ActiveCard, parent);
        activeCard.GetComponent<ActiveCardUI>().SetupCard(card, audioSourceCarthridge);
        activeCard.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
    }
}
