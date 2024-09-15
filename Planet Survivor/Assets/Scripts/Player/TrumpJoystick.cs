using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpJoystick : MonoBehaviour
{
    [HideInInspector] 
    public Joystick joystick;
    [HideInInspector]
    public float playerSpeed;
    [HideInInspector]
    public Vector2 lastMovedVector;


    //referencias
    Rigidbody2D rb;
    TrumpStats player;

    void Start ()
    {
        player = GetComponent<TrumpStats>();
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1,0f);        
    }


    void FixedUpdate() 
    {
        if(joystick.Direction.y != 0 || joystick.Direction.x != 0)
        {
            rb.velocity = new Vector2(joystick.Direction.x * player.currentMoveSpeed, joystick.Direction.y * player.currentMoveSpeed);
            lastMovedVector = new Vector2(joystick.Direction.x, joystick.Direction.y);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }   

    


    
}
