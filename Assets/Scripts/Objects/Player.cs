using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int Health { get; set; }
    public int Progress { get; set; }
    public List<Card> Hand { get; set; }
    public int MaxHealth;

    public List<DaemonCard> activeDaemonCards = new List<DaemonCard>();
    public List<Card> AvailableCards;

    public Player()
    {
        Health = 100;
        MaxHealth = 100;
        Progress = 0;
        Hand = new List<Card>();
        AvailableCards = new() { AttackCardsLibrary.CyberSlash, DefenseCardsLibrary.Firewall, ProgressCardLibrary.DataHarvest };
    }

    // Игрок наносит урон врагу
    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    // Игрок добавляет прогресс
    public void AddProgress(int progress)
    {
        Progress += progress;
    }

    // Игрок добавляет защиту
    public void AddDefense(int defense)
    {
        // Добавить защиту
    }

    // Применение эффекта от Daemon карты
    public void AddDaemonEffect(DaemonCard daemonCard)
    {
        activeDaemonCards.Add(daemonCard);
    }

    // Игрок может сыграть карту
    public void PlayCard(Card card, Enemy target)
    {
        card.PlayCard(this, target);
    }

    public Card GetRandomCardFromAvailableCards()
    {
        int randomIndex = Random.Range(0, AvailableCards.Count);
        Card randomCard = AvailableCards[randomIndex];
        return randomCard;
    }
}
