using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObjects enemyData;

    float currentMoveSpeed;
    float currentHealth;
    float currentDamage;


    void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }


    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);   
    }


    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            TrumpStats player = col.gameObject.GetComponent<TrumpStats>();
            player.TakeDamage(currentDamage); //se for usar multiplicador de dano usa currentDamage, se nao usa weaponData.damage
        }
    }



}
