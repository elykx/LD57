using UnityEngine;

public class QuantumCard : Card
{
    public int DamageOption1 { get; set; }
    public int BlockOption2 { get; set; }

    public QuantumCard(string name, int cost, int damageOption1, int blockOption2)
    {
        CardName = name;
        Cost = cost;
        DamageOption1 = damageOption1;
        BlockOption2 = blockOption2;
    }

    public override void PlayCard(Player player, Enemy target)
    {
        int choice = Random.Range(0, 2);

        if (choice == 0)
        {
            Debug.Log($"Использована квантовая карта {CardName}, нанесено {DamageOption1} урона.");
            target.TakeDamage(DamageOption1);
        }
        else
        {
            Debug.Log($"Использована квантовая карта {CardName}, заблокировано {BlockOption2} урона.");
            player.AddDefense(BlockOption2);
        }
    }
}
