using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwitcher : MonoBehaviour
{
    public List<Sprite> sprites;
    public float switchInterval = 1f;

    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(SwitchSprite());
    }

    IEnumerator SwitchSprite()
    {
        while (true)
        {
            spriteRenderer.sprite = sprites[currentSpriteIndex];

            currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Count;

            yield return new WaitForSeconds(switchInterval);
        }
    }
}
