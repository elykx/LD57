using UnityEngine;

public class AttackCard : Card
{
    public int Damage { get; set; }

    public AttackCard(string name, int cost, int damage, string consoleText)
    {
        CardName = name;
        Cost = cost;
        Damage = damage;
        ConsoleText = consoleText;
    }

    public override void PlayCard(Player player, Enemy target)
    {
        Debug.Log($"Использована карта атаки {CardName}, урон: {Damage}");
        target.TakeDamage(Damage);
    }
}

public static class AttackCardsLibrary
{
    public static AttackCard CyberSlash = new AttackCard("Cyber Slash", 2, 10,
    "> injecting payload...\n" +
    "> target://node_0324 accessed\n" +
    "> executing [cyber_slash.vx]\n" +
    "> ███████████████▓▒░ done.\n" +
    "> damage packet delivered: 27μB\n" +
    "> node integrity reduced.");
}