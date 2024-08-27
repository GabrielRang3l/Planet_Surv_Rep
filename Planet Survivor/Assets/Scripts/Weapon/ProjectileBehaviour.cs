using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : ProjectileWaponBehaviour
{
    ProjetioBase pb;
    protected override void Start()
    {
        base.Start();
        pb = FindObjectOfType<ProjetioBase>();
    }

    
    void Update()
    {
        // Aplicando o movimento para o projetil
        transform.position += direction * pb.speed * Time.deltaTime; 

    }
}
