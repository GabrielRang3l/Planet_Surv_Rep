using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float bulletLifespan = 5f;   // How long the bullet lasts before disappearing
    private bool playerHit = false;     // Track if the player was hit

    void Start()
    {
        // Destroy the bullet after its lifespan expires
        Invoke("DestroyProjectile", bulletLifespan);
    }

    // Detect collisions using triggers
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet hits the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("PLAYER HIT");  // Log message when player is hit
            playerHit = true;         // Mark that the player was hit
            Destroy(gameObject);      // Destroy the bullet on collision with the player
        }
    }

    // Method to destroy the projectile after its lifespan
    void DestroyProjectile()
    {
        // If the player wasn't hit before the bullet is destroyed, log "PROJECTILE MISS"
        if (!playerHit)
        {
            Debug.Log("PROJECTILE MISS");
        }
        Destroy(gameObject);  // Destroy the projectile
    }
}
