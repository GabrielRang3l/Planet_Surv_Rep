using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControler : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject prefab;
    public float speed;
    public float damage;
    public float cooldownDuration;
    float currentCooldown;
    public int pierce;
    void Start()
    {
        currentCooldown = cooldownDuration;
    }


    void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f)
        {
            Attack();
        }
    }

    void Attack()
    {
        currentCooldown = cooldownDuration;
    }
}
