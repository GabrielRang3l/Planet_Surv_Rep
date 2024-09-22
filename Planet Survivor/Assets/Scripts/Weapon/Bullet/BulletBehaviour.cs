using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class BulletBehaviour : WeaponProjectileBehaviour
{


    public GameObject bulletPrefab; // Prefab of the bullet
    public float shootingInterval = 1f; // Time between shots
    public float detectionRadius = 10f; // Radius to detect enemies

    private float nextShootTime = 0f; // Timer for shooting

    AudioSource au;

    [Header("Configurações de Som")]
    [SerializeField] AudioClip[] clips;

    
    protected override void Start() 
    {
        base.Start();
        
        if (GameObject.Find("SFXManager").GetComponent<SFXManager>().PlaySFX)  //TOCA O SOM DO TIRO

        {
            au = GetComponent<AudioSource>();

            au.clip = clips[Random.Range(0, clips.Length - 1)];
            au.Play();
        }           
    }
  
    void Update()
    {
        // Aplicando o movimento para o projetil
        //transform.position += direction * currentSpeed * Time.deltaTime; 
        if (Time.time >= nextShootTime)
        {
            GameObject target = FindNearestEnemy();
            if (target != null)
            {
                Shoot(target);
                nextShootTime = Time.time + shootingInterval; // Set next shoot time
            }
        }
    }

    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float closestDistance = detectionRadius;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    void Shoot(GameObject target)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Vector2 direction = (target.transform.position - transform.position).normalized;
    }

       
}
