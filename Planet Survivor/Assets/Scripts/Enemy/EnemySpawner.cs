using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups;
        public int waveQuota;                   //numero total de inimigos que vao spawnar na wave
        public int spawnCount;                  //numero de inimigos spawnados na wave
        public float spawnInterval;             //intervalo entre spawn de inimigos
        
    }

    [System.Serializable]
    public class EnemyGroup 
    {
        public string enemyName;
        public int enemyCount;                  //numero de imimigos que vao spawnar na wave
        public int spawnCount;                  //numero de inimigos spawnados na wave
        public GameObject enemyPrefab;          //lista de prefab dos inimigos que vao spawnar na wave
    }

    public List<Wave> waves;                    //lista de todas as waves do jogo
    public int currentWaveCount;

    [Header("Spawn Timer")]
    float spawnTimer;                           //determina o tempo de spawn entre inimigos
    public int enemiesAlive;
    public int maxEnemiesAllowed;               //numero maximo de inimigos permitido no mapa
    public bool maxEnemiesReached = false;      //indica se o numero maximo de inimigos na fase foi alcan�ado
    public float waveIntervals;                 //intervalo entre as waves


    [Header("Posi��o dos Spawns")]
    public List<Transform> relativeSpawnPoints; //lista pra guardar todos os spawn points dos inimigos





    Transform player;

    void Start()
    {
        player = FindAnyObjectByType<TrumpStats>().transform;    
        CalculteWaveQuota();

    }


    void Update()
    {
        if (currentWaveCount < waves.Count && waves[currentWaveCount].spawnCount == 0) //verifica se a wave terminou e a proxima wave deve iniciar
        {
            StartCoroutine(BeginNextWave());
        }

        spawnTimer += Time.deltaTime;
        
        //verifica se � hora de spawnar o proximo inimigo
        if (spawnTimer >= waves[currentWaveCount].spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemies();    
        }
    }

    IEnumerator BeginNextWave()
    {



        yield return new WaitForSeconds(waveIntervals);

        if(currentWaveCount < waves.Count - 1)
        {
            currentWaveCount++;
            CalculteWaveQuota();
        }
    }


    void CalculteWaveQuota()
    {
        int currentWaveQuota = 0;
        foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota =+ enemyGroup.enemyCount;
        }

        waves[currentWaveCount].waveQuota = currentWaveQuota;

    }


    void SpawnEnemies()
    {
        // verifica se o numero minimo de inimigos da wave foi spawnado
        if (waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota && !maxEnemiesReached)
        {
            //spawna cada tipo de inimigo at� a cota ser atingida
            foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
            {
                //verifica se o numero minimo deste tipo inimigo foi spawnado
                if(enemyGroup.spawnCount < enemyGroup.enemyCount)
                {
                    if(enemiesAlive >= maxEnemiesAllowed)
                    {
                        maxEnemiesReached = true;
                        return;
                    }

                    //spawna inimigos em uma posi�ao aleatoria proxima do jogador
                    Instantiate(enemyGroup.enemyPrefab, player.position + relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position,Quaternion.identity);

                    enemyGroup.spawnCount++;
                    waves[currentWaveCount].spawnCount++;
                    enemiesAlive++;
                }
            }
        }

        if(enemiesAlive < maxEnemiesAllowed)
        {
            maxEnemiesReached = false;
        }
    }


    //chame essa fun��o quando um inimigo � morto
    public void OnEnemyKilled()
    {
        //diminui o numero de inimigos vivos
        enemiesAlive--;
    }

}
