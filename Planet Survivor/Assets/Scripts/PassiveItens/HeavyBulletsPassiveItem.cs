using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBulletsPassiveItem : PassiveItem
{
    protected override void ApplyModifier()
    {
        player.currentMight *= 1 + passiveItemData.Multipler / 100f;
    }
}
