using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : Cat
{
    public LayerMask scratchpostLayer;

    protected override void Update()
    {
        base.Update();
        CheckScratchpostProximity();
    }

    protected void CheckScratchpostProximity()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f, scratchpostLayer);

        if (colliders.Length > 0)
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("Ragdoll2");
        }
        else
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("Ragdoll");
        }
    }
}
