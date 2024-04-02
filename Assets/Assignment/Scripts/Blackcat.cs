using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackcat : Cat
{
    public GameObject fishbowl2;
    public LayerMask fishbowlLayer;

    protected override void Update()
    {
        base.Update();
        CheckFishbowlProximity();
    }

    protected void CheckFishbowlProximity()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f, fishbowlLayer);

        if (colliders.Length > 0)
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("Blackcat2");
            fishbowl2.SetActive(true);
        }
        else
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("Blackcat");
            fishbowl2.SetActive(false);
        }
    }
}

