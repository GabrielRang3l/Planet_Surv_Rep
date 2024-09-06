using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpJoystick : MonoBehaviour
{
    public Joystick joystick;
    Rigidbody2D rb;
    public float playerSpeed;
    [HideInInspector]
    public Vector2 lastVector;
  
    

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        lastVector = new Vector2(1,0f);
        
        
    }


    void FixedUpdate() 
    {
        if(joystick.Direction.y != 0 || joystick.Direction.x != 0)
        {
            rb.velocity = new Vector2(joystick.Direction.x * playerSpeed, joystick.Direction.y * playerSpeed);
            lastVector = new Vector2(joystick.Direction.x , joystick.Direction.y);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }   

    


    
}
