using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetioBase : WeaponControler
{ 

     protected override void Start()
    {
        base.Start();
    }

    
   protected override void Attack ()
    {
        base.Attack ();
        GameObject spawnedProjetio = Instantiate(prefab);
        spawnedProjetio.transform.position = transform.position; //Tornando a mesma possi��o do objeto base, que ser� o player      
        spawnedProjetio.GetComponent<ProjectileBehaviour>().DirectionChecker(jsm.lastMovedVector); // Referenciando e definindo dire��o
         
                                                                                                              
    }
}
