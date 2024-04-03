using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishbowl : MonoBehaviour
{
    public Sprite fishbowl1Sprite; 
    public Sprite fishbowl2Sprite; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Blackcat"))
        {
            ChangeSprite(fishbowl2Sprite); 
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
