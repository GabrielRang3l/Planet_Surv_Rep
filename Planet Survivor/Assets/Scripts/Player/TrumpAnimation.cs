using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpAnimation : MonoBehaviour
{

    Animator am;
    TrumpJoystick tjs; // esse é o scrip de movimento do trump
    SpriteRenderer sr;


    void Start()
    {
        am = GetComponent<Animator>();
        tjs = GetComponent<TrumpJoystick>();
        sr = GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        if (tjs.joystick.Direction.y != 0 || tjs.joystick.Direction.x != 0)
        {
            am.SetBool("IsRuning", true);
            SideChecker();
        }
        else
        {
            am.SetBool("IsRuning", false);
        }
    }

    private void SideChecker ()
    {
        if (tjs.joystick.Direction.x < 0 )
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
