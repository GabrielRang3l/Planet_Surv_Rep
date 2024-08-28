using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpFollow : MonoBehaviour
{

    [SerializeField] Transform Target;
    public float Modifier;
    bool isFollowing = false;


    Vector2 Velocity = Vector2.zero;


    public void StartFollowing()
    {
        isFollowing = true;
    }


    // Update is called once per frame
    void Update()
    {

        if (isFollowing)
        {
            transform.position = Vector2.SmoothDamp(transform.position, Target.position, ref Velocity, Time.deltaTime * Modifier);
        }
       
    }
}
