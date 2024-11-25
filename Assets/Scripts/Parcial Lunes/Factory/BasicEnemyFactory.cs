using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyFactory : IEnemyFactory
{
    private GameObject[] enemyPrefabs;

    public BasicEnemyFactory(GameObject[] enemyPrefabs)
    {
        this.enemyPrefabs = enemyPrefabs;
    }

    public GameObject CreateEnemy(Transform spawnPoint)
    {
        GameObject randomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        return Object.Instantiate(randomEnemy, spawnPoint.position, Quaternion.identity);
    }
}
