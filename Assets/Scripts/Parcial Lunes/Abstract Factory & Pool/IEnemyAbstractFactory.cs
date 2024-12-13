using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyAbstractFactory
{
    IEnemyFactory CreateBasicEnemyFactory();
    IEnemyFactory CreateAdvancedEnemyFactory();
}

