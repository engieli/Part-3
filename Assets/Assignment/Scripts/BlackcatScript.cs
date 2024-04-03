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

    protected override  void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (other.CompareTag("Fishbowl"))
        {
            if (FishbowlTrigger)
            {
                SwitchSprite(Blackcat2);
            }
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);

        if (other.CompareTag("Fishbowl"))
        {
         
        }
    }
}

