using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseMov : MonoBehaviour
{
    Transform Player;
    [Header("Base Move")]

    public float moveSpeed;

    void Start()
    {
        Player = FindAnyObjectByType<JoyStickMove>().transform;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, moveSpeed
            * Time.deltaTime);
    }
}
