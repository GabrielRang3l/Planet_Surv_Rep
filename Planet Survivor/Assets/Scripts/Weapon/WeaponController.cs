using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponData;
      
    public float currentCooldown;
  
    protected TrumpJoystick tjs;


    protected virtual void Start()
    {
        tjs = FindObjectOfType<TrumpJoystick>();
        currentCooldown = weaponData.CooldownDuration; // Faz o tiro não ser atirado assim que o jogo começa 
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
        currentCooldown = weaponData.CooldownDuration;
    }
}
