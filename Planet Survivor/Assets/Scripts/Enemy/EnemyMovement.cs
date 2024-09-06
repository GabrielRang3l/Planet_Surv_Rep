using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyScriptableObjects enemyData;

    [Header("Alvo do inimigo")]
    [SerializeField] Transform Player;  //pede o transform do alvo

    //Rigidbody2D rb;


     void Start()
    {
        Player = FindAnyObjectByType<TrumpJoystick>().transform;
        //rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, enemyData.MoveSpeed * Time.deltaTime);

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
