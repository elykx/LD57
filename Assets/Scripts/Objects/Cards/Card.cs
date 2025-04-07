using System.Collections.Generic;
using UnityEngine;

public abstract class Card
{
    public string CardName { get; set; }
    public string Description { get; set; }
    public int Cost { get; set; }
    public int Progress;
    public string ConsoleText;
    public Sprite Icon;

    public abstract void PlayCard(Player player, Enemy target, Level level);
}

public enum CardTag
{
    Virus,
    Encryption,
    Protocol
}

public enum VisualType
{
    CardCommon,
    QuadCard,
}

public abstract class TaggedCard : Card
{
    public List<CardTag> Tags { get; set; }

    public void AddTag(CardTag tag)
    {
        if (!Tags.Contains(tag))
            Tags.Add(tag);
    }
}

public class VirusCard : TaggedCard
{
    public int Damage { get; set; }

    public VirusCard()
    {
        Tags = new List<CardTag> { CardTag.Virus };
    }

    public override void PlayCard(Player player, Enemy target, Level level)
    {
        target.TakeDamage(Damage);
        level.AddProgress(Progress);
    }
}