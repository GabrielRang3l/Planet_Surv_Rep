using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [Header("Alvo do inimigo")]
    [SerializeField] Transform Player;  //pede o transform do alvo
    EnemyStats enemy;
    Transform enemytransform;
    SpriteRenderer sr;

    Vector2 knockbackVelocity;
    float knockbackDuration;


     void Start()
    {
        enemy = GetComponent<EnemyStats>();
        Player = FindAnyObjectByType<TrumpJoystick>().transform;      
        enemytransform = GetComponent<Transform>();
        
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, enemy.currentMoveSpeed * Time.deltaTime);

        
        if(knockbackDuration > 0 )
        {
            transform.position += (Vector3)knockbackVelocity * Time.deltaTime;
            knockbackDuration -= Time.deltaTime;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, enemy.currentMoveSpeed * Time.deltaTime);
        }

    }
   

    public void Knockback(Vector2 velocity, float duration)
    {
        if (knockbackDuration > 0) return;


        knockbackVelocity = velocity;
        knockbackDuration = duration;   
    }

 







}
