using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class BulletBehaviour : ProjectileWeaponBehaviour
{

    BulletController bc;
    AudioSource au;

    [Header("Configurações de Som")]
    [SerializeField] AudioClip[] clips;

    
    protected override void Start() 
    {
        base.Start();
        bc = FindObjectOfType<BulletController>();
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
        transform.position += direction * bc.speed * Time.deltaTime; 

    }
}
