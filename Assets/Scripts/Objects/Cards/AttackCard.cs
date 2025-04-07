using UnityEngine;

public class AttackCard : Card
{
    public int Damage { get; set; }

    public AttackCard(string name, int cost, int damage, string consoleText, int progress, Sprite sprite, string description)
    {
        CardName = name;
        Cost = cost;
        Damage = damage;
        ConsoleText = consoleText;
        Progress = progress;
        Icon = sprite;
        Description = description;
    }

    public override void PlayCard(Player player, Enemy target, Level level)
    {
        target.TakeDamage(Damage);
        level.AddProgress(Progress);
        level.MinusEnergy(Cost);
    }
}
