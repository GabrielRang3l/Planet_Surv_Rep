using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TrumpKeyboard : MonoBehaviour
{
    Rigidbody2D rb;
    [HideInInspector]
    public Vector2 moveDir;

    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;


    [SerializeField] float moveSpeed;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

 
    void Update()
    {
        InputManagement();
    }


     void FixedUpdate()
    {
        Move();
    }



    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if(moveDir.y != 0 )
        {
            lastVerticalVector = moveDir.y;
        }

    }


    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }

}
