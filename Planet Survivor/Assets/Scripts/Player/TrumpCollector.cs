using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpCollector : MonoBehaviour
{
    TrumpStats player;
    CircleCollider2D playerCollector;


    [Header("Modifica o raio de coleta")]
    public float pullSpeed;

    [Header("VFX de Coletar")]
    [SerializeField] GameObject CollectVFX;

    

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
            //essa é a animação do item sendo puxado ao jogador
            //vector 2 aponta o item para o player
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
            Vector2 forceDirection = (transform.position - col.transform.position).normalized;
            rb.AddForce(forceDirection * pullSpeed);

            Instantiate(CollectVFX, gameObject.transform.position, transform.rotation);

            //se houver chama o metodo Collect
            collectible.Collect();
        }
    }
}
