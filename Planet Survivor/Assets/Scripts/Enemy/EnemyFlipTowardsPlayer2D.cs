using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlipTowardsPlayer2D : MonoBehaviour
{
    public Transform player;  // The player's transform
    private SpriteRenderer spriteRenderer;  // Reference to the sprite renderer

    void Start()
    {
        // Find the player using the tag "Player"
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Get the SpriteRenderer component from the object
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player != null)
        {
            // Check the direction to the player
            if (player.position.x < transform.position.x)
            {
                // Player is to the left, flip the sprite to face left
                spriteRenderer.flipX = true;
            }
            else if (player.position.x > transform.position.x)
            {
                // Player is to the right, flip the sprite to face right
                spriteRenderer.flipX = false;
            }
        }
    }
}
