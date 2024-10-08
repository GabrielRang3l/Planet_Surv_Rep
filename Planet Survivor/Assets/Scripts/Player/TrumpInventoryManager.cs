using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpInventoryManager : MonoBehaviour
{

    public List<WeaponController> weaponSlots = new List<WeaponController>(6);
    public int[] weaponLevels = new int[6];
    public List<PassiveItem> PassiveItemSlots = new List<PassiveItem>(6);
    public int[] passiveItemSlots = new int[6];


    public void AddWeapon(int slotIndex, WeaponController weapon)
    {
        weaponSlots[slotIndex] = weapon;
        weaponLevels[slotIndex] = weapon.weaponData.Level;
    }

    public void AddPassiveItem(int slotIndex, PassiveItem passiveItem)
    {
        passiveItemSlots[slotIndex] = passiveItem;
       
    } 


    public void LevelUpWeapon(int slotIndex)
    {

    }


    public void LevelUpPassiveItem(int slotIndex)
    {

    }


}
