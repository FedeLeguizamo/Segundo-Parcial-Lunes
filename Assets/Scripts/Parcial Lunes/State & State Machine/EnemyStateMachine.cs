using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class EnemyStateMachine
{
    private IEnemyState currentState;

    public void SetState(IEnemyState newState, Enemy enemy)
    {
        // Salir del estado actual
        if (currentState != null)
        {
            currentState.ExitState(enemy);
        }

        // Configurar el nuevo estado
        currentState = newState;
        currentState.EnterState(enemy);
    }

    public void Update(Enemy enemy)
    {
        if (currentState != null)
        {
            currentState.UpdateState(enemy);
        }

        // Lógica de transición de estados según la distancia al jugador
        float distance = Vector2.Distance(enemy.transform.position, enemy.player.position);

        if (distance > enemy.stoppingDistance && !(currentState is ChaseState))
        {
            SetState(new ChaseState(), enemy);
        }
        else if (distance <= enemy.stoppingDistance && distance > enemy.retreatDistance && !(currentState is IdleState))
        {
            SetState(new IdleState(), enemy);
        }
        else if (distance <= enemy.retreatDistance && !(currentState is RetreatState))
        {
            SetState(new RetreatState(), enemy);
        }
    }
}

