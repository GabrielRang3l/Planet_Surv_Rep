using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponProjectileBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;

    public float destroyAfterSeconds;
    protected Vector3 direction;


    //status atuais

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


    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;

        
        float dirx = direction.x;
        float diry = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if(dirx < 0 && diry < 0)
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        }

        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);
        
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        //referencia do script collider e causa dano usando TakeDamage
        if (col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);  //use "currentDamage" inves de "weaponData.Damage" se quiser usar multiplicador de dano no futuro
            ReducePierce();
        }
        else if (col.CompareTag("Prop"))
        {
            if(col.gameObject.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamage(currentDamage);
                ReducePierce();
            }
        }

    }


    void ReducePierce() //destroy o projetil quando o pierce chegar a 0
    {
        currentePierce--;
        if(currentePierce <= 0)
        {
            Destroy(gameObject);
        }
    }






}



