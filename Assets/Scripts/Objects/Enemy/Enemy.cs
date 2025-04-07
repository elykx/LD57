using UnityEngine;

public abstract class Enemy
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Health { get; set; }
    public string ConsoleText;
    public int SpawnIndex;
    public int Damage { get; set; }

    public Sprite Sprite;

    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public abstract void PerformAction(Player player);
}
