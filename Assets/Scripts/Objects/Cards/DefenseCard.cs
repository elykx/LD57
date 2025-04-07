using UnityEngine;

public class DefenseCard : Card
{
    public int DefenseValue { get; set; }

    public DefenseCard(string name, int cost, int defenseValue, string consoleText, int progress, Sprite sprite, string description)
    {
        CardName = name;
        Cost = cost;
        DefenseValue = defenseValue;
        ConsoleText = consoleText;
        Progress = progress;
        Icon = sprite;
        Description = description;
    }

    public override void PlayCard(Player player, Enemy target, Level level)
    {
        Debug.Log($"Использована карта защиты {CardName}, защита: {DefenseValue}");
        player.AddDefense(DefenseValue);
        level.AddProgress(Progress);
        level.MinusEnergy(Cost);
    }
}
