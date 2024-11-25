using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Wave
{
    public string waveName;
    public int numberOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
    
}

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] Wave[] waves;
    public Transform[] spawnPoints;
    public Animator animator;
    public Text waveName;
    public Text Victory;

    private Wave currentWave;
    private int currentWaveNumber; //saber en q wave estamos
    private IEnemyFactory enemyFactory;

    private bool canSpawn = true;
    private float spawnTime;
    private bool canAnimate = false;
    
    private void Start()
    {
        currentWaveNumber = 0;
        currentWave = waves[currentWaveNumber];
        enemyFactory = new BasicEnemyFactory(currentWave.typeOfEnemies);
    }

    private void Update()
    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (totalEnemies.Length == 0 && currentWaveNumber + 1 != waves.Length && canAnimate)
        {

            waveName.text = waves[currentWaveNumber + 1].waveName;
            animator.SetTrigger("WaveComplete");     //lo pone en el texto de la prox wave
            canAnimate = false;       // si se mataron todos los enemigos y no se pueden spawnear mas
                                      //se cambia a la proxima wave

        }
        else
        {

        }

    }

    private void SpawnWave()
    {
        if (canSpawn && spawnTime < Time.time)
        {
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            enemyFactory.CreateEnemy(randomPoint); // Usamos la fábrica

            currentWave.numberOfEnemies--;
            spawnTime = Time.time + currentWave.spawnInterval;

            if (currentWave.numberOfEnemies == 0)
            {
                canSpawn = false;
                canAnimate = true;
            }
        }
    }

    private void SpawnNextWave()
    {
        currentWaveNumber++;
        currentWave = waves[currentWaveNumber];
        enemyFactory = new BasicEnemyFactory(currentWave.typeOfEnemies); // Actualizar la fábrica
        canSpawn = true;
    }
}




