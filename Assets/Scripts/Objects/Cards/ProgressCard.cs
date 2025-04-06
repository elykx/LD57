using System;
using UnityEngine;

public class ProgressCard : Card
{
    public ProgressCard(string name, int cost, string consoleText, int progress)
    {
        CardName = name;
        Cost = cost;
        ConsoleText = consoleText;
        Progress = progress;
    }

    public override void PlayCard(Player player, Enemy target, Level level)
    {
        Debug.Log($"Использована карта прогресса {CardName}, прогресс: {Progress}");
        player.AddProgress(Progress);
        level.AddProgress(Progress);
    }
}

public static class ProgressCardLibrary
{
    public static ProgressCard DataHarvest = new ProgressCard("Data Harvest", 2,
    "> establishing siphon link...\n" +
    "> accessing datastore://corp_mainframe\n" +
    "> initializing [harvest_routine.py]\n" +
    "> ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ done (3.2s)\n" +
    "> collected: 54μB // decrypted: 38μB\n" +
    "> data uploaded to vault://local_node", 5);
}