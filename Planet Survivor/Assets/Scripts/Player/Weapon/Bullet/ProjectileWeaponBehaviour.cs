using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Script base para todos os projeteis do jogo 

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    protected Vector3 direction;
    public float destroyAfterSeconds;

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }


    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}



