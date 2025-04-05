using UnityEngine;

public abstract class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    public string ConsoleText;

    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public abstract void PerformAction(Player player);
}
