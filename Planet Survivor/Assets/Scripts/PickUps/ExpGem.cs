using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpGem : Pickup, ICollectible
{
    public int experienceGranted;

    public void Collect()
    {
        TrumpStats player = FindAnyObjectByType<TrumpStats>();
        player.IncreaseExperience(experienceGranted);
      
    }

}
