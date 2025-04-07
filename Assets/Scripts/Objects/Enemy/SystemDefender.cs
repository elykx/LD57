using System;
using UnityEngine;

public class SystemDefender : Enemy
{
    public int Defense { get; set; }

    public SystemDefender(string name, int health, int defense, int damage, string consoleText, Sprite sprite, string description)
    {
        Name = name;
        Health = health;
        Defense = defense;
        Damage = damage;
        ConsoleText = consoleText;
        Sprite = sprite;
        Description = description;
    }

    public override void TakeDamage(int damage)
    {
        int reducedDamage = Mathf.Max(damage - Defense, 0);  // Снижаем урон на защиту
        Health -= reducedDamage;
        Debug.Log($"Враг {Name} получил {reducedDamage} урона, осталось здоровья: {Health}");
    }

    public override void PerformAction(Player player)
    {
        Debug.Log($"{Name} атакует игрока.");
        player.TakeDamage(Damage);  // Враг атакует игрока
    }
}