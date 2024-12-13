using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbstractFactory : IEnemyAbstractFactory
{
    private GameObject[] basicEnemyPrefabs;
    private GameObject[] advancedEnemyPrefabs;

    public EnemyAbstractFactory(GameObject[] basicEnemies, GameObject[] advancedEnemies)
    {
        basicEnemyPrefabs = basicEnemies;
        advancedEnemyPrefabs = advancedEnemies;
    }

    public IEnemyFactory CreateBasicEnemyFactory()
    {
        return new BasicEnemyFactory(basicEnemyPrefabs);
    }

    public IEnemyFactory CreateAdvancedEnemyFactory()
    {
        return new AdvancedEnemyFactory(advancedEnemyPrefabs);
    }
}

