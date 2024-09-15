using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [Header("Alvo do inimigo")]
    [SerializeField] Transform Player;  //pede o transform do alvo
    EnemyStats enemy;
    //Rigidbody2D rb;


     void Start()
    {
        enemy = GetComponent<EnemyStats>();
        Player = FindAnyObjectByType<TrumpJoystick>().transform;      
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, enemy.currentMoveSpeed * Time.deltaTime);

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
       // if (collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        
    }

    public void TakeDamage(int damage)
    {
        //hp -= damage;
        
        //if (hp < 1)
        {
            Destroy(gameObject);
        }

    }

}
