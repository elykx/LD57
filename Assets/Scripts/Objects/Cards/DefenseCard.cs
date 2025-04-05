using UnityEngine;

public class DefenseCard : Card
{
    public int DefenseValue { get; set; }

    public DefenseCard(string name, int cost, int defenseValue)
    {
        CardName = name;
        Cost = cost;
        DefenseValue = defenseValue;
    }

    public override void PlayCard(Player player, Enemy target)
    {
        Debug.Log($"Использована карта защиты {CardName}, защита: {DefenseValue}");
        player.AddDefense(DefenseValue);
    }
}