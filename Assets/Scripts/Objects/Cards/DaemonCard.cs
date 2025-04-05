using UnityEngine;

public class DaemonCard : Card
{
    public int DamagePerTurn { get; set; }

    public DaemonCard(string name, int cost, int damagePerTurn)
    {
        CardName = name;
        Cost = cost;
        DamagePerTurn = damagePerTurn;
    }

    public override void PlayCard(Player player, Enemy target)
    {
        Debug.Log($"Пассивная карта {CardName} активирована. Каждый ход наносит {DamagePerTurn} урона.");
        player.AddDaemonEffect(this);
    }
}