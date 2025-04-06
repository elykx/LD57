
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorEnemyHealthUI : MonoBehaviour
{
    public SpriteRenderer image;
    public Sprite active;
    public Sprite disabled;
    public TMP_Text healthText;
    public int index;

    void Update()
    {
        bool isAlive = G.enemyManager.Enemies.Exists(e => e.SpawnIndex == index);
        if (!isAlive)
        {
            image.sprite = disabled;
            healthText.enabled = false;
        }
        else
        {
            foreach (Enemy enemy in G.enemyManager.Enemies)
            {
                if (enemy.SpawnIndex == index)
                {
                    image.sprite = active;
                    healthText.enabled = true;
                    if (enemy.Health > 0)
                    {

                        healthText.text = enemy.Health.ToString();
                    }
                    else
                    {
                        healthText.text = "0";
                    }
                }
            }
        }
    }
}