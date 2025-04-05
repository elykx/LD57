using UnityEngine;

public class SystemDefender : Enemy
{
    public int Defense { get; set; }

    public SystemDefender(string name, int health, int defense)
    {
        Name = name;
        Health = health;
        Defense = defense;
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
        player.TakeDamage(5);  // Враг атакует игрока
    }
}