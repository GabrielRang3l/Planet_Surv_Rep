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

    protected TrumpJoystick tjs;
    protected virtual void Start()
    {
        tjs = FindObjectOfType<TrumpJoystick>();
        currentCooldown = cooldownDuration; // Faz o tiro não ser atirado assim que o jogo começa 
    }


    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f)     // Se cooldown for 0, attack
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currentCooldown = cooldownDuration;
    }
}
