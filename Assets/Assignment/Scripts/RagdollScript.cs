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

    public override void SwitchSprite(Sprite newSprite)
    {
        base.SwitchSprite(newSprite);

        if (newSprite == Ragdoll2 && ScratchpostTrigger)
        {
            // Implementation specific to Ragdoll and ScratchpostTrigger
        }
    }
}
