using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : WeaponController
{ 
    
     protected override void Start()
    {
        base.Start();
    }

    
   protected override void Attack ()
    {
        base.Attack ();
        GameObject spawnedBullet = Instantiate(weaponData.Prefab);
        spawnedBullet.transform.position = transform.position;     
        spawnedBullet.GetComponent<BulletBehaviour>().DirectionChecker(tjs.lastVector); 


    }
}
