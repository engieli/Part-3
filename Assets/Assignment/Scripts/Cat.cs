using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

using UnityEngine;

using UnityEngine;

public class Cat : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected SpriteRenderer spriteRenderer;
    protected bool isSelected;

    public float moveSpeed = 5f; // Speed at which the cat moves

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            HandleClick(); // Check for mouse click
        }

        if (isSelected)
        {
            HandleInput(); // Check for keyboard input only if this cat is selected
        }
    }

    void HandleClick()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            if (!isSelected)
            {
                Select(); // Select this cat if clicked on
            }
        }
        else
        {
            Deselect(); // Deselect this cat if clicked outside
        }
    }

    void HandleInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);
        Move(moveDirection);
    }

    public virtual void Move(Vector2 direction)
    {
        rb.velocity = direction * moveSpeed;
    }

    public virtual void Select()
    {
        isSelected = true;
  
    }

    public virtual void Deselect()
    {
        isSelected = false;
        rb.velocity = Vector2.zero; 
    }

    public virtual void SwitchSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the cat collided with a Fishbowl
        if (other.CompareTag("Fishbowl"))
        {
            BlackcatScript blackcatScript = GetComponent<BlackcatScript>();
            if (blackcatScript != null)
            {
                SwitchSprite(blackcatScript.Blackcat2);
            }
        }
        // Check if the cat collided with a Scratchpost
        else if (other.CompareTag("Scratchpost"))
        {
            RagdollScript ragdollScript = GetComponent<RagdollScript>();
            if (ragdollScript != null)
            {
                SwitchSprite(ragdollScript.Ragdoll2);
            }
        }
    }
}
