using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ProjectileBehaviour : ProjectileWeaponBehaviour
{
    ProjectileBase pb;
    
    AudioSource au;
    [Header("Configurações de Som")]
    [SerializeField] AudioClip[] clips;

    

    protected override void Start()
    {
        if (GameObject.Find("SFXManager").GetComponent<SFXManager>().PlaySFX)
        {
            au = GetComponent<AudioSource>();

            au.clip = clips[Random.Range(0, clips.Length - 1)];
            au.Play();
        }

        base.Start();
        pb = FindObjectOfType<ProjectileBase>();
    }

    
    void Update()
    {
        // Aplicando o movimento para o projetil
        transform.position += direction * pb.speed * Time.deltaTime; 

    }
}
