using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActiveCardUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text cardNameText;
    public TMP_Text costText;

    private Card currentCard;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetupCard(Card card)
    {
        spriteRenderer.enabled = true;
        currentCard = card;

        if (cardNameText != null)
            cardNameText.text = currentCard.CardName;

        if (costText != null)
            costText.text = currentCard.Cost.ToString();

        AnimateCard();
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    private void AnimateCard()
    {
        Vector3 startPosition = new Vector3(-2.2f, 0f, 5f);
        Vector3 targetPosition = new Vector3(-1f, 0f, 5f);
        Tween.LocalPosition(gameObject.transform, startPosition, 0.5f, Ease.InOutQuad).OnComplete(() =>
        {
            Tween.LocalPosition(gameObject.transform, targetPosition, 0.5f, Ease.InOutQuad).OnComplete(() =>
        {
            Tween.LocalPositionY(gameObject.transform, 0.25f, 0.25f, Ease.InOutQuad, 1).OnComplete(() =>
            {
                Tween.LocalPositionY(gameObject.transform, 0f, 0.25f, Ease.InOutQuad);
            });
        });

        });
    }


}