using UnityEngine;

public class DefenseCard : Card
{
    public int DefenseValue { get; set; }

    public DefenseCard(string name, int cost, int defenseValue, string consoleText)
    {
        CardName = name;
        Cost = cost;
        DefenseValue = defenseValue;
        ConsoleText = consoleText;
    }

    public override void PlayCard(Player player, Enemy target)
    {
        Debug.Log($"Использована карта защиты {CardName}, защита: {DefenseValue}");
        player.AddDefense(DefenseValue);
    }
}

public static class DefenseCardsLibrary
{
    public static DefenseCard Firewall = new DefenseCard("Firewall", 3, 5,
    "> deploying defense module...\n" +
    "> initiating firewall.shield\n" +
    "> binding to port 443\n" +
    "> incoming threats: redirected\n" +
    "> [OK] active protection enabled (v2.1.4)");
}