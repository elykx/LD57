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
        Health = 25;
        MaxHealth = 25;
        Progress = 0;
        Hand = new List<Card>();
        AvailableCards = new() { AttackCardsLibrary.CyberSlash };
        // , DefenseCardsLibrary.Firewall, ProgressCardLibrary.DataHarvest 
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public void AddProgress(int progress)
    {
        Progress += progress;
    }

    public void AddDefense(int defense)
    {

    }

    public void AddDaemonEffect(DaemonCard daemonCard)
    {
        activeDaemonCards.Add(daemonCard);
    }

    public Card GetRandomCardFromAvailableCards()
    {
        int randomIndex = Random.Range(0, AvailableCards.Count);
        Card randomCard = AvailableCards[randomIndex];
        return randomCard;
    }
}
