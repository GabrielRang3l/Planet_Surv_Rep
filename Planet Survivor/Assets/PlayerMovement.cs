using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(moveX, moveY, 0);
    }
}
