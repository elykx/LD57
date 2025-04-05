using UnityEngine;

public class ProgressCard : Card
{
    public int Progress { get; set; }

    public ProgressCard(string name, int cost, int progress)
    {
        CardName = name;
        Cost = cost;
        Progress = progress;
    }

    public override void PlayCard(Player player, Enemy target)
    {
        Debug.Log($"Использована карта прогресса {CardName}, прогресс: {Progress}");
        player.AddProgress(Progress);
    }
}
