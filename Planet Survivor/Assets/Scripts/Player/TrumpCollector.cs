using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpCollector : MonoBehaviour
{
    TrumpStats player;
    CircleCollider2D playerCollector;
    public float pullSpeed;

    void Start()
    {
        player = FindObjectOfType<TrumpStats>();
        playerCollector = GetComponent<CircleCollider2D>();
    }


    void Update()
    {
        playerCollector.radius = player.currentMagnet;
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        //verifica se o gameObject tem a interface ICollectible
        if (col.gameObject.TryGetComponent(out ICollectible collectible))
        {
            //essa � a anima��o do item sendo puxado ao jogador
            //vector 2 aponta o item para o player
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
            Vector2 forceDirection = (transform.position - col.transform.position).normalized;
            rb.AddForce(forceDirection * pullSpeed);

            //se houver chama o metodo Collect
            collectible.Collect();
        }
    }
}
