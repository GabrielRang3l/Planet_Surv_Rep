using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpCollector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        //verifica se o gameObject tem a interface ICollectible
        if (col.gameObject.TryGetComponent(out ICollectible collectible))
        {

            //se houver chama o metodo Collect
            collectible.Collect();
        }
    }
}
