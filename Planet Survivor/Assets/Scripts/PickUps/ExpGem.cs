using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpGem : MonoBehaviour, ICollectible
{
    public int experienceGranted;

    public void Collect()
    {
        TrumpStats player = FindAnyObjectByType<TrumpStats>();
        player.IncreaseExperience(experienceGranted);
        Destroy(gameObject);
    }

}
