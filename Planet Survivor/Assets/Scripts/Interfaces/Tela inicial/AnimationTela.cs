using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTela : MonoBehaviour
{

    Animator animator;
    float state = 0f;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetFloat("IsTransition", 1);


    }

    void Animation ()
    {

    }
}
