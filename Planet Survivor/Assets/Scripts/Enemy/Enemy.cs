using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [Header("Movimento do Inimigo")]
    [SerializeField] float speed;       //da a velocidade do inimigo

    [Header("Alvo do inimigo")]
    [SerializeField] Transform Target;  //pede o transform do alvo

    GameObject targetGameObject;        // serve pro inimigo identificar se está colidindo com o player ou outra coisa
    Rigidbody2D rb;

    [SerializeField] int hp = 10;

    


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        targetGameObject = Target.gameObject;
        //Target = FindAnyObjectByType<TrumpJoystick>().transform;
        
    }

    void FixedUpdate()
    {
        Vector3 direction = (Target.position - transform.position).normalized;
        rb.velocity = direction * speed;


    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        
        if (hp < 1)
        {
            Destroy(gameObject);
        }

    }




}



    


/*  
 [Header("Velocidade do Inimigo")]
 [SerializeField] float moveSpeed;

 Transform Player;





 Rigidbody2D rb;


  private void Awake()
  {
     rb = GetComponent<Rigidbody2D>();
      TargetGameObject = Player.gameObject;

  }


  void Start()
 {
     Player = FindAnyObjectByType<JoyStickMove>().transform;
 }

  private void FixedUpdate()
  {
      Vector3 direction = (TargetDestination.position - transform.position).normalized;
      rb.velocity = direction * moveSpeed;
  }




void FixedUpdate()
  {
      transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
  }




private void Attack()
{
    Debug.Log("está atacando");
}


public Transform Target;
    [SerializeField] float speed;

    Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        Vector3 direction = (Target.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }


*/
