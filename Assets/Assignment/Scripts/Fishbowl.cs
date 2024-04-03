using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishbowl : MonoBehaviour
{
    public Sprite fishbowl1Sprite; // Sprite for Fishbowl1
    public Sprite fishbowl2Sprite; // Sprite for Fishbowl2

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Blackcat"))
        {
            ChangeSprite(fishbowl2Sprite); // Change to Fishbowl2 sprite when Blackcat is near
        }
    }


    void ChangeSprite(Sprite newSprite)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = newSprite;
        }
    }
}
