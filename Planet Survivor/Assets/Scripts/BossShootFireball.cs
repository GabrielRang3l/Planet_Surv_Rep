using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShootFireball : MonoBehaviour
{
    public Transform player;                   // Reference to the player
    public GameObject fireballPrefab;           // The fireball prefab
    public float homingAttackDistance = 10f;    // Distance to switch to homing attack
    public float fireballSpeed = 5f;            // Speed of fireballs
    public int circularFireballCount = 8;       // Number of fireballs in circular pattern
    public float circularFireballAngle = 360f;  // Full angle of circular attack

    private float fireballCooldown = 1f;        // Cooldown between shots
    private float nextFireTime = 0f;            // Track next time to fire

    void Update()
    {
        // Check if it's time to fire
        if (Time.time >= nextFireTime)
        {
            // Determine the distance to the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= homingAttackDistance)
            {
                // Player is close, fire in a circular pattern
                FireCircularPattern();
            }
            else
            {
                // Player is far away, fire a homing shot
                FireHomingShot();
            }
            nextFireTime = Time.time + fireballCooldown; // Reset cooldown
        }
    }

    void FireHomingShot()
    {
        // Instantiate a homing fireball
        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        FireballHoming fireballHoming = fireball.GetComponent<FireballHoming>();
        fireballHoming.SetTarget(player);
        fireballHoming.SetSpeed(fireballSpeed);
        fireballHoming.SetHomingStrength(1000f); // Set desired homing strength
    }

    void FireCircularPattern()
    {
        // Fire fireballs in a circular pattern
        for (int i = 0; i < circularFireballCount; i++)
        {
            float angle = i * (circularFireballAngle / circularFireballCount); // Calculate angle for each fireball
            Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0); // Get direction

            // Instantiate fireball
            GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
            FireballHoming fireballHoming = fireball.GetComponent<FireballHoming>();
            fireballHoming.SetTarget(player); // Optional: Use the player's position if needed
            fireballHoming.SetSpeed(fireballSpeed);
            fireballHoming.SetHomingStrength(0f); // Disable homing for circular fireballs
            fireball.transform.up = direction; // Set the direction of the fireball
        }
    }
}
