using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObjects enemyData;

    //current stats
    [HideInInspector]
    public float currentMoveSpeed;
    [HideInInspector]
    public float currentHealth;
    [HideInInspector]
    public float currentDamage;

    public float despawnDistance = 8f;
    Transform player;


    [Header("Damage Feedback")]
    public Color damageColor = new Color(1,0,0,1);
    public float damageFlashDuration = 0.2f;
    public float deathFadeTime = 0.6f;
    Color originalColor;
    SpriteRenderer sr;
    EnemyMovement movement;


    public ParticleSystem damageEffect;


    void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }


    void Start()
    {
        player = FindAnyObjectByType<TrumpStats>().transform;
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;

        movement = GetComponent<EnemyMovement>();
    }


    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) >= despawnDistance)
        {
            ReturnEnemy();
        }
    }


    public void TakeDamage(float dmg, Vector2 sourcePosition, float knockbackForce = 1f, float knockbackDuration = 0.2f)
    {
        currentHealth -= dmg;
        StartCoroutine(DamageFlash());
        

        if (knockbackForce > 0)
        {
            Vector2 dir = (Vector2)transform.position - sourcePosition;
            movement.Knockback(dir.normalized * knockbackForce, knockbackDuration);
        }



        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    IEnumerator DamageFlash()
    {
        sr.color = damageColor;
        yield return new WaitForSeconds(damageFlashDuration);
        sr.color = originalColor;
    }



    public void Kill()
    {
       
        Destroy(gameObject);   
    }


    private void OnCollisionStay2D(Collision2D col)
    {
        if (damageEffect) Instantiate(damageEffect, transform.position, Quaternion.identity); //GERA PARTICULAS QUANDO ATINGIDO

        if (col.gameObject.CompareTag("Player"))
        {
            TrumpStats player = col.gameObject.GetComponent<TrumpStats>();
            player.TakeDamage(currentDamage); //se for usar multiplicador de dano usa currentDamage, se nao usa weaponData.damage
           
        }
    }

    private void OnDestroy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        es.OnEnemyKilled();
    }


    void ReturnEnemy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        transform.position = player.position + es.relativeSpawnPoints[UnityEngine.Random.Range(0, es.relativeSpawnPoints.Count)].position;
    }



}
