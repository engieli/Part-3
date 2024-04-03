using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackcatScript : Cat
{
    public Sprite Blackcat;
    public Sprite Blackcat2;
    public bool FishbowlTrigger;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void SwitchSprite(Sprite newSprite)
    {
        base.SwitchSprite(newSprite);

        if (newSprite == Blackcat2 && FishbowlTrigger)
        {
            SwitchToBlackcat2Sprite();
        }
    }

    void SwitchToBlackcat2Sprite()
    {
        spriteRenderer.sprite = Blackcat2;
    }
}
