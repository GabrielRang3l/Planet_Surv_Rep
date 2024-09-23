using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponProjectileBehaviour : MonoBehaviour
{
    [Header("Status da arma puxando de: ")]
    public WeaponScriptableObject weaponData;

    [Header("Tempo de vida do Projetil ")]
    public float destroyAfterSeconds;

    protected Vector3 direction;

    [Header("Animação de Acerto")]
    [SerializeField] GameObject[] enemyBulletVFX;
    [SerializeField] GameObject propBulletVFX;


    //status atuais
    float currentDamage;
    [HideInInspector]
    public float currentSpeed;
    float currentCooldownDuration;
    protected int currentPierce;


     void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    /*
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
    */
    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        //referencia do script collider e causa dano usando TakeDamage
        if (col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);  //use "currentDamage" inves de "weaponData.Damage" se quiser usar multiplicador de dano no futuro
            ReducePierce();
            Instantiate(enemyBulletVFX[Random.Range(0, enemyBulletVFX.Length - 1)], gameObject.transform.position, Quaternion.identity);
            
        }
        else if (col.CompareTag("Prop"))
        {
            if(col.gameObject.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamage(currentDamage);
                ReducePierce(); 
                Instantiate(propBulletVFX, gameObject.transform.position, Quaternion.identity);
                Destroy(propBulletVFX);
            }
        }

    }


    void ReducePierce() //destroy o projetil quando o pierce chegar a 0
    {
        currentPierce--;
        if(currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }






}



