using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMeleeBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;

    public float destroyAfterSeconds;

    float currentDamage;
    float currentSpeed;
    float currentCooldownDuration;
    protected int currentePierce;


    void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentePierce = weaponData.Pierce;
    }



    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }


    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        //referencia do script collider e causa dano usando TakeDamage
        if (col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);  //use "currentDamage" inves de "weaponData.Damage" se quiser usar multiplicador de dano no futuro
          
        }
        else if (col.CompareTag("Prop"))
        {
            if (col.gameObject.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamage(currentDamage);
                
            }
        }

    }


}
