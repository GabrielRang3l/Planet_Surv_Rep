using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItem : MonoBehaviour
{

    protected TrumpStats player;
    public PassiveItemScriptableObject passiveItemData;

    protected virtual void ApplyModifier()
    {

    }

    void Start()
    {
        player = GetComponent<TrumpStats>();
        ApplyModifier();
    }

    void Update()
    {
        
    }
}
