using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public SpriteRenderer damage;
    public SpriteRenderer def;
    public TMP_Text damageText;
    public TMP_Text defText;

    private SpriteRenderer sr;
    private Enemy currentEnemy;
    private TooltipTrigger tooltipTrigger;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        tooltipTrigger = GetComponent<TooltipTrigger>();
    }

    public void SetupEnemy(Enemy enemy)
    {
        currentEnemy = enemy;

        if (enemy.Sprite != null)
        {
            sr.sprite = enemy.Sprite;
        }

        damageText.text = enemy.Damage.ToString();
        if (enemy is SystemDefender)
        {
            def.enabled = true;
            defText.text = ((SystemDefender)enemy).Defense.ToString();
        } else {
            def.enabled = false;
            defText.text = "";
        }
        tooltipTrigger.tooltipTitle = enemy.Name;
        tooltipTrigger.tooltipContent = enemy.Description;

    }

    void Update()
    {
        if (currentEnemy != null && currentEnemy.Health <= 0)
        {
            G.enemyManager.RemoveEnemy(currentEnemy);
            Destroy(gameObject);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        G.enemyManager.ChoiceEnemy(currentEnemy);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (currentEnemy != null)
        {
            Tween.Scale(transform, new Vector3(1.1f, 1.1f, 1f), 0.2f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (currentEnemy != null)
        {
            Tween.Scale(transform, new Vector3(1f, 1f, 1f), 0.2f);
        }
    }
}