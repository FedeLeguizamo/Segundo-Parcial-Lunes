using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedEnemyFactory : IEnemyFactory
{
    private GameObject[] advancedEnemyPrefabs;

    public AdvancedEnemyFactory(GameObject[] enemyPrefabs)
    {
        advancedEnemyPrefabs = enemyPrefabs;
    }

    public GameObject CreateEnemy(Transform spawnPoint)
    {
        GameObject randomEnemy = advancedEnemyPrefabs[Random.Range(0, advancedEnemyPrefabs.Length)];
        GameObject enemy = Object.Instantiate(randomEnemy, spawnPoint.position, Quaternion.identity);
        
        enemy.GetComponent<Enemy>().speed *= 2.0f; // Ejemplo: enemigos avanzados son más rápidos
        return enemy;
    }
}

