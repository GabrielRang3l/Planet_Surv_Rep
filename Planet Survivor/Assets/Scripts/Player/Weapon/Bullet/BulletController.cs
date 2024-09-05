using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : WeaponControler
{ 
    
     protected override void Start()
    {
        base.Start();
    }

    
   protected override void Attack ()
    {
        base.Attack ();
        GameObject spawnedProjectile = Instantiate(prefab);
        spawnedProjectile.transform.position = transform.position; //Tornando a mesma posição do objeto base, que será o player      
        spawnedProjectile.GetComponent<BulletBehaviour>().DirectionChecker(tjs.lastDirection); // Referenciando e definindo direção


    }
}
