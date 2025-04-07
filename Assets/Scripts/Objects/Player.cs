using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player
{
    public int Health { get; set; }
    public int Progress { get; set; }
    public List<Card> Hand { get; set; }
    public int MaxHealth;

    public List<DaemonCard> activeDaemonCards = new List<DaemonCard>();

    public Player()
    {
        Health = 30;
        MaxHealth = 30;
        Progress = 0;
        Hand = new List<Card>();
    }



    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Health = 0;
        }
    }

    public void AddProgress(int progress)
    {
        Progress += progress;
    }

    public void AddDefense(int defense)
    {
        Health += defense;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    public void AddDaemonEffect(DaemonCard daemonCard)
    {
        activeDaemonCards.Add(daemonCard);
    }

}
