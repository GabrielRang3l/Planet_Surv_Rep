using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FundoAnimation : MonoBehaviour
{
    Animation am;
    MoveByTouch mbt;

    void Start()
    {
        am = GetComponent<Animation>();
        mbt = GetComponent<MoveByTouch>();
    }

    void Update()
    {
        if (mbt.isTouch = true)
        {
           
        }
    }

    
}
