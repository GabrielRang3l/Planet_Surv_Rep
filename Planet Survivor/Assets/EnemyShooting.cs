using System.Collections;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectilePrefab;  // Reference to the projectile prefab
    public Transform shootingPoint;      // Where the bullets are shot from
    public float startShootingRange = 10f;   // The range within which the enemy starts shooting
    public float bulletVelocity = 10f;       // The speed of the bullets
    public float colliderSize = 0.5f;        // The size of the CircleCollider2D and projectile sprite
    public float shootingInterval = 2f;      // Time between each round of shots

    private Transform player;                // Reference to the player
    private bool isShooting = false;         // To prevent multiple firing at once

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;  // Find the player by tag
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Check if within shooting range
        if (distanceToPlayer <= startShootingRange && !isShooting)
        {
            StartCoroutine(ShootTripleShot());
        }
    }

    IEnumerator ShootTripleShot()
    {
        isShooting = true;  // Prevent multiple coroutines from running

        // Calculate the direction to the player
        Vector2 directionToPlayer = (player.position - shootingPoint.position).normalized;

        // Fire three bullets:
        ShootBullet(directionToPlayer, 0);   // Middle bullet towards the player
        ShootBullet(directionToPlayer, 45);  // 45 degrees upwards
        ShootBullet(directionToPlayer, -45); // 45 degrees downwards

        // Wait for the next shooting interval
        yield return new WaitForSeconds(shootingInterval);
        isShooting = false;  // Allow shooting again
    }

    void ShootBullet(Vector2 direction, float angleOffset)
    {
        // Create a bullet instance
        GameObject bullet = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);

        // Adjust the size of the CircleCollider2D based on the colliderSize variable
        CircleCollider2D collider = bullet.GetComponent<CircleCollider2D>();
        if (collider != null)
        {
            collider.radius = colliderSize;  // Adjust the radius
        }

        // Adjust the bullet sprite size to match the collider size
        bullet.transform.localScale = new Vector3(colliderSize * 2f, colliderSize * 2f, 1f);

        // Rotate the direction by the specified angle offset
        Vector2 finalDirection = Quaternion.Euler(0, 0, angleOffset) * direction;

        // Set the bullet velocity
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = finalDirection * bulletVelocity;
    }
}
