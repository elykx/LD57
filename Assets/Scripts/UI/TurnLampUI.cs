using System.Collections;
using UnityEngine;

public class TurnLampUI : MonoBehaviour
{
    public Sprite baseSprite;
    public Sprite greenSprite;
    public Sprite redSprite;
    public float switchInterval = 1f;

    private SpriteRenderer spriteRenderer;
    private Coroutine switchCoroutine;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateStateSprite();
    }

    private void Update()
    {
        UpdateStateSprite();
    }

    private void UpdateStateSprite()
    {
        GameState currentState = G.gameStateManager.CurrentState;

        if (switchCoroutine != null)
        {
            StopCoroutine(switchCoroutine);
            switchCoroutine = null;
        }

        if (currentState == GameState.PlayerTurn)
        {
            switchCoroutine = StartCoroutine(BlinkSprite(greenSprite));
        }
        else if (currentState == GameState.EnemyTurn)
        {
            switchCoroutine = StartCoroutine(BlinkSprite(redSprite));
        }
        else
        {
            spriteRenderer.sprite = baseSprite;
        }
    }

    private IEnumerator BlinkSprite(Sprite mainSprite)
    {
        bool toggle = false;

        while (true)
        {
            spriteRenderer.sprite = toggle ? baseSprite : mainSprite;
            toggle = !toggle;

            yield return new WaitForSeconds(switchInterval);
        }
    }
}