using System;
using UnityEngine;

public class ProgressCard : Card
{
    public int Progress { get; set; }

    public ProgressCard(string name, int cost, int progress, string consoleText)
    {
        CardName = name;
        Cost = cost;
        Progress = progress;
        ConsoleText = consoleText;
    }

    public override void PlayCard(Player player, Enemy target)
    {
        Debug.Log($"Использована карта прогресса {CardName}, прогресс: {Progress}");
        player.AddProgress(Progress);
    }
}

public static class ProgressCardLibrary
{
    public static ProgressCard DataHarvest = new ProgressCard("Data Harvest", 2, 15,
    "> establishing siphon link...\n" +
    "> accessing datastore://corp_mainframe\n" +
    "> initializing [harvest_routine.py]\n" +
    "> ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ done (3.2s)\n" +
    "> collected: 54μB // decrypted: 38μB\n" +
    "> data uploaded to vault://local_node");
}