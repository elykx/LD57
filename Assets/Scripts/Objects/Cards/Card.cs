using System.Collections.Generic;
using UnityEngine;

public abstract class Card
{
    public string CardName { get; set; }
    public int Cost { get; set; }

    public abstract void PlayCard(Player player, Enemy target);
}

// Теги карт
public enum CardTag
{
    Virus,
    Encryption,
    Protocol
}

// Базовый класс карты с тегами
public abstract class TaggedCard : Card
{
    public List<CardTag> Tags { get; set; }

    public void AddTag(CardTag tag)
    {
        if (!Tags.Contains(tag))
            Tags.Add(tag);
    }
}

// Пример карты с тегами
public class VirusCard : TaggedCard
{
    public int Damage { get; set; }

    public VirusCard()
    {
        Tags = new List<CardTag> { CardTag.Virus };
    }

    public override void PlayCard(Player player, Enemy target)
    {
        target.TakeDamage(Damage);
    }
}