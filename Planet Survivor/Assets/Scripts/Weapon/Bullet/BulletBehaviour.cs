using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;


public class BulletBehaviour : WeaponProjectileBehaviour
{

    AudioSource au;

    [Header("Configura��es de Som")]
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
        transform.position += direction * currentSpeed * Time.deltaTime; 
     
    }




}
