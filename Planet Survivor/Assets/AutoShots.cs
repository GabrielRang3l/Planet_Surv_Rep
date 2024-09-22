using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShots : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab of the bullet
    public float shootingInterval = 1f; // Time between shots
    public float bulletSpeed = 10f; // Speed of the bullet
    public float detectionRadius = 10f; // Radius to detect enemies

    private float nextShootTime = 0f; // Timer for shooting

    void Update()
    {
        if (Time.time >= nextShootTime)
        {
            GameObject target = FindNearestEnemy();
            if (target != null)
            {
                Shoot(target);
                nextShootTime = Time.time + shootingInterval; // Set next shoot time
            }
        }
    }

    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float closestDistance = detectionRadius;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    void Shoot(GameObject target)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Debug.Log("Bullet fired!"); // Log when a bullet is fired

        Vector2 direction = (target.transform.position - transform.position).normalized;
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = direction * bulletSpeed;

        // Log bullet velocity
        Debug.Log("Bullet Velocity: " + bulletRb.velocity);
    }
}
