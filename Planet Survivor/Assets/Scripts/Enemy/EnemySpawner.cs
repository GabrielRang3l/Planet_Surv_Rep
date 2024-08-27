using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Frequencia de spawn dos inimigos
    [Header("Tempo entre os spawns")]
    [SerializeField] private float spawnRate = 1f;

    //Vetor de inimigos
    [Header("Prefab de Inimigos")]
    [SerializeField] private GameObject[] enemyPrefabs;

    //Booleano se inimigo pode nascer
    [Header("Alternar Spawn")]
    [SerializeField] private bool canSpawn = true;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;

            //Variável random pra aleatoriedades do spawn de inimigos. Nesse caso é um vetor "exclusivo", ou seja, é contado a partir do número 0, então nao precisa por -1 no final do random
            int random = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[random];

            //Nascer o inimigo na area de acordo com a direçao que foi montado o prefab, por isso o quaternion
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            
        }
    }

}
