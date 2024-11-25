using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState
{
    void EnterState(Enemy enemy); // Acciones al entrar en este estado
    void UpdateState(Enemy enemy); // Lógica que se ejecuta en cada frame
    void ExitState(Enemy enemy); // Acciones al salir de este estado
}