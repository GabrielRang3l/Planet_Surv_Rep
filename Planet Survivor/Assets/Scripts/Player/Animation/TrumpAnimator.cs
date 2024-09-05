using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    Animator am;
    TrumpKeyboard tkb;
    SpriteRenderer sr;


    void Start()
    {
        am = GetComponent<Animator>();
        tkb = GetComponent<TrumpKeyboard>();
        sr = GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        if (tkb.moveDir.x != 0 || tkb.moveDir.y != 0)
        {
            am.SetBool("Move", true);
            SideChecker();
        }
        else
        {
            am.SetBool("Move", false);
        }
    }


    private void SideChecker()
    {
        if (tkb.lastHorizontalVector < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
