using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Script base para todos os projeteis do jogo 
/// </summary>
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}