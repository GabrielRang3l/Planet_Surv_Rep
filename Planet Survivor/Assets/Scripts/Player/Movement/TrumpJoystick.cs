using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpJoystick : MonoBehaviour
{
    public Joystick joystick;

    [SerializeField] float playerSpeed;

    Rigidbody2D rb;

    [HideInInspector]
    public Vector3 movementVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public float lastHorizontalVector;

    public Vector2 lastDirection;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
        lastDirection = new Vector2(1f, 0f);
    }


    void Update() //toma conta da movimentação do player usando o scrip "JOYSTICK"
    {
        
        movementVector *= playerSpeed;
        rb.velocity = movementVector;
        
        if (movementVector.x != 0)
        {
            lastHorizontalVector = movementVector.x;
        }
        if (movementVector.y != 0)
        {
            lastVerticalVector = movementVector.y;
        }



        if (joystick.Direction.y !=0)
        {
            rb.velocity = new Vector2(joystick.Direction.x * playerSpeed, joystick.Direction.y * playerSpeed);

            lastDirection = new Vector2(lastHorizontalVector, lastVerticalVector);

            /* if (joystick.Direction.x != 0)
             {
                 lastHorizontalVector = movementVector.x;
             }
             if (joystick.Direction.x != 0)
             {
                 lastVerticalVector = movementVector.y;
             }*/

       
        }
        else
        {
            rb.velocity = Vector2.zero;
        }


        if (joystick.Direction.x != 0 && joystick.Direction.y != 0)
        {
            lastDirection = new Vector2(lastHorizontalVector, lastVerticalVector);
        }

    }
}
