using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : MonoBehaviour
{


    [SerializeField] float timeToAtack = 4f;
    float timer;
    [SerializeField] GameObject LeftSwordObject;
    [SerializeField] GameObject RightSwordObject;

    TrumpJoystick TrumpJoystick;


    [SerializeField] Vector2 swordAttackSize = new Vector2(3f, 1f);

    [SerializeField] int swordDamage = 1;



    void Awake()
    {
        TrumpJoystick = GetComponentInParent<TrumpJoystick>();
    }

    
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }

    }
    private void Attack()
    {
        timer = timeToAtack;

        if (TrumpJoystick.joystick.Direction.x > 0)
        {
            RightSwordObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(RightSwordObject.transform.position, swordAttackSize, 0f);
         
            
        }

        if (TrumpJoystick.joystick.Direction.y > 0)
        {
            LeftSwordObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(LeftSwordObject.transform.position, swordAttackSize, 0f);
            
        }
    }


    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++) 
        {
            Enemy e = colliders[i].GetComponent<Enemy>();
            if (e != null)
            {
                colliders[i].GetComponent<Enemy>().TakeDamage(swordDamage);
            }
            
        }
    }



}
