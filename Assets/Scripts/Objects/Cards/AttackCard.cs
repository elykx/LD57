using UnityEngine;

public class AttackCard : Card
{
    public int Damage { get; set; }

    public AttackCard(string name, int cost, int damage)
    {
        CardName = name;
        Cost = cost;
        Damage = damage;
    }

    public override void PlayCard(Player player, Enemy target)
    {
        Debug.Log($"Использована карта атаки {CardName}, урон: {Damage}");
        target.TakeDamage(Damage);
    }
}

public static class AttackCardsLibrary {
    public static AttackCard CyberSlash = new AttackCard("Cyber Slash", 2, 10);
}