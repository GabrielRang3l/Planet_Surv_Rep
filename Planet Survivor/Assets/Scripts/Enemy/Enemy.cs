using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

}

    /*

    Transform Player;
    [Header("Movimento do Inimigo")]
    public float moveSpeed;
    Rigidbody2D rb;

    GameObject TargetGameObject; // serve pro inimigo identificar se está colidindo com o player ou outra coisa

    void Start()
    {
        Player = FindAnyObjectByType<JoyStickMove>().transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 direction = (Player.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;


    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == TargetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        
    }
}
    */


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
