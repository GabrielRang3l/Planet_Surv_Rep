using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : Pickup, ICollectible
{
    public int healthToRestore;


    public void Collect()
    {
        TrumpStats player = FindAnyObjectByType<TrumpStats>();
        player.RestoreHealth(healthToRestore);
     
    }
}
