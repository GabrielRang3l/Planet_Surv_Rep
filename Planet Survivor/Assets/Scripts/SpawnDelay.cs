using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDelay : MonoBehaviour
{
    public float delay = 1f; // Tempo de espera em segundos

    private void Start()
    {
        StartCoroutine(MoveAfterDelayCoroutine());
    }

    private IEnumerator MoveAfterDelayCoroutine()
    {
        // Espera pelo tempo especificado
        yield return new WaitForSeconds(delay);

    }
}
