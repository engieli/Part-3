using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RagdollScript : Cat
{
    public Sprite Ragdoll;
    public Sprite Ragdoll2;
    public bool ScratchpostTrigger;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (other.CompareTag("Scratchpost"))
        {
            if (ScratchpostTrigger)
            {
                SwitchSprite(Ragdoll2);
            }
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);

        if (other.CompareTag("Scratchpost"))
        {
            SwitchSprite(Ragdoll);
        }
    }
}



