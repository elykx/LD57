using System;
using UnityEngine;

public class ProgressCard : Card
{
    public ProgressCard(string name, int cost, string consoleText, int progress, Sprite sprite, string description)
    {
        CardName = name;
        Cost = cost;
        ConsoleText = consoleText;
        Progress = progress;
        Icon = sprite;
        Description = description;
    }

    public override void PlayCard(Player player, Enemy target, Level level)
    {
        Debug.Log($"Использована карта прогресса {CardName}, прогресс: {Progress}");
        level.AddProgress(Progress);
        level.MinusEnergy(Cost);
    }
}
