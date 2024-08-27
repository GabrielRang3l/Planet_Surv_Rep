using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickMove : MonoBehaviour
{
    private Rigidbody2D rb;


    [Header("Inserir o Script _FloatingJoystick")] public Joystick movementJoystick;
    [Header("Altera a velocidade do jogador")] public float playerSpeed;


    [HideInInspector]
    public Vector2 lastMovedVector; // Vetor que guarda ultima posição 
   

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f);
       
    }

    private void FixedUpdate()
    {
        if (movementJoystick.Direction.y != 0 )
        {
            rb.velocity = new Vector2(movementJoystick.Direction.x * playerSpeed, movementJoystick.Direction.y * playerSpeed);
            lastMovedVector = new Vector2(movementJoystick.Direction.x, movementJoystick.Direction.y);
            
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if(movementJoystick.Direction.x != 0 && movementJoystick.Direction.y != 0 )
        {
            lastMovedVector = new Vector2(movementJoystick.Direction.x, movementJoystick.Direction.y);
           
        }
    }
}
