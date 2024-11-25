using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatState : IEnemyState
{
    public void EnterState(Enemy enemy)
    {
        
    }

    public void UpdateState(Enemy enemy)
    {
        enemy.transform.position = Vector2.MoveTowards(
            enemy.transform.position,
            enemy.player.position,
            -enemy.speed * Time.deltaTime);
    }

    public void ExitState(Enemy enemy)
    {
        
    }
}

