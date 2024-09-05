using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpStats : MonoBehaviour
{

    public int maxHP = 10;
    public int currentHp = 10;




    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            Debug.Log("morreu");
        }

    }


}
