using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpJoystick : MonoBehaviour
{
    public Joystick joystick;
    [SerializeField] float playerSpeed;
    [SerializeField] Camera Camera;
    Rigidbody2D rb;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate() //toma conta da movimentação do player usando o scrip "JOYSTICK"
    {
        if (joystick.Direction.y !=0)
        {
            rb.velocity = new Vector2(joystick.Direction.x * playerSpeed, joystick.Direction.y * playerSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
