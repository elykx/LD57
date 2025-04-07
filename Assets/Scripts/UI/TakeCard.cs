
using UnityEngine;
using UnityEngine.UI;

public class TakeCard : MonoBehaviour
{
    public Image sr;

    private Card currentCard;
    public void SetCurrentCard(Card card)
    {
        currentCard = card;
        if (card.Icon != null)
            sr.sprite = card.Icon;
    }
    public void AddToHand()
    {
        G.handManager.AddCardToHand(currentCard);
    }

    public void AddToAvailable()
    {
        SessionData.Instance.AddCardToAvailable(currentCard);
    }


}