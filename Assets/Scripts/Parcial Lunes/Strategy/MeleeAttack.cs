using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class MeleeAttackStrategy : IAttackStrategy
{
    public void Attack(GameObject attacker, GameObject target, float damage)
    {
        if (target.TryGetComponent<Health>(out Health health))
        {
            health.dmgTaken += damage; 
        }
    }
}

