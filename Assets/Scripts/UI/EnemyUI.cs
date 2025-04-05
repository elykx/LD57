using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text enemyNameText;
    private Enemy currentEnemy;

    public void SetupEnemy(Enemy enemy)
    {
        currentEnemy = enemy;

        if (enemyNameText != null)
            enemyNameText.text = enemy.Name;

    }

    void Update()
    {
        if (currentEnemy != null && currentEnemy.Health <= 0)
        {
            G.enemyManager.RemoveEnemy(currentEnemy);
            Destroy(gameObject);
        }
    }

    // Этот метод вызывается при клике на карту
    public void OnPointerClick(PointerEventData eventData)
    {
        G.enemyManager.ChoiceEnemy(currentEnemy);
    }

    // Этот метод вызывается при наведении на карту
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (currentEnemy != null)
        {
            Debug.Log("Mouse entered on: " + currentEnemy.Name);
            Tween.Scale(transform, new Vector3(1.1f, 1.1f, 1f), 0.2f);
        }
    }

    // Этот метод вызывается при убирании мыши с карты
    public void OnPointerExit(PointerEventData eventData)
    {
        if (currentEnemy != null)
        {
            Debug.Log("Mouse exited from: " + currentEnemy.Name);
            // Здесь можно вернуть масштаб обратно
            Tween.Scale(transform, new Vector3(1f, 1f, 1f), 0.2f);
        }
    }
}