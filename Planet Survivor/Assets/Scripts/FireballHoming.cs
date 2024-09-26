using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.RuleTile.TilingRuleOutput;

public class FireballHoming : MonoBehaviour
{
    public EnemyScriptableObjects enemyData;

    private Transform target;            // The player
    private float speed;                 // Speed of the fireball
    private float baseHomingStrength;    // Base homing strength (adjusted by distance)
    public float lifeTime = 5f;          // How long the fireball will live before it is destroyed
    public float inaccuracyFactor = 1f;  // How much inaccuracy to add
    private bool isOnScreen = false;     // Check if the fireball has entered the screen
    private float screenLifeTimer;       // Timer to track life when on screen

    public ParticleSystem damageEffect;

    void Start()
    {
        screenLifeTimer = lifeTime; // Set the initial life time but don't start counting yet
    }

    void Update()
    {
        if (target != null)
        {
            // Check if the fireball is on screen before starting the life timer
            if (IsOnScreen() && !isOnScreen)
            {
                isOnScreen = true;  // Fireball is now on screen
                StartCoroutine(StartLifeTimer()); // Start the life timer only when on screen
            }

            // Calculate the direction to the player
            Vector3 direction = (target.position - transform.position).normalized;

            // Calculate the distance to the player
            float distanceToPlayer = Vector3.Distance(transform.position, target.position);

            // Adjust homing strength based on distance (stronger when farther, weaker when closer)
            float adjustedHomingStrength = Mathf.Lerp(baseHomingStrength, 0, distanceToPlayer / 10f);  // Homing weakens when closer

            // Introduce some inaccuracy (random offset) that increases as the fireball gets closer
            float inaccuracy = Mathf.Lerp(0, inaccuracyFactor, 1f - distanceToPlayer / 10f);
            Vector3 randomOffset = new Vector3(
                Random.Range(-inaccuracy, inaccuracy),
                Random.Range(-inaccuracy, inaccuracy),
                0
            );

            // Move direction with added random inaccuracy
            Vector3 moveDirection = Vector3.Lerp(transform.up, direction + randomOffset, adjustedHomingStrength * Time.deltaTime).normalized;

            // Update fireball position
            transform.position += moveDirection * speed * Time.deltaTime;
        }
    }

    // Coroutine for life timer after entering the screen
    private IEnumerator StartLifeTimer()
    {
        yield return new WaitForSeconds(screenLifeTimer);
        Destroy(gameObject);  // Fireball missed and is destroyed
    }

    // Set the target for the fireball (player)
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    // Set the fireball's speed
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    // Set the base homing strength
    public void SetHomingStrength(float newHomingStrength)
    {
        baseHomingStrength = newHomingStrength;
    }

    // Check if the fireball is on screen using the camera's viewport
    private bool IsOnScreen()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1;
    }

    // Detect collision with the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (damageEffect) Instantiate(damageEffect, transform.position, Quaternion.identity); //GERA PARTICULAS QUANDO ATINGIDO

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);  // Destroy the fireball on hit
        }
    }
}

