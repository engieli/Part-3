using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cat : MonoBehaviour
{
    protected static int catCount = 0; // Static variable to keep track of the number of cats

    protected Rigidbody2D rb;
    protected SpriteRenderer spriteRenderer;
    protected bool isSelected;

    public float moveSpeed = 5f; // Speed at which the cat moves

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Increment the cat count when a new cat is created
        catCount++;
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
                StartCoroutine(SelectionDelay()); // Start the coroutine for selection delay
            }
        }
        else
        {
            Deselect(); // Deselect this cat if clicked outside
        }
    }

    IEnumerator SelectionDelay()
    {
        yield return new WaitForSeconds(0.5f); // Wait for half a second

        Select(); // Select this cat after the delay
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
        rb.velocity = Vector2.zero; // Stop the cat's movement when deselected

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

    // Static function to get the total number of cats
    public static int GetCatCount()
    {
        return catCount;
    }
}
