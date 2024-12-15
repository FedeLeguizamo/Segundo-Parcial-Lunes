using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

using UnityEngine;

public class MakePlayerInvincibleCommand : ICommand
{
    private string playerTag = "Player"; 

    public void Execute()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag); 

        if (player != null && player.TryGetComponent<Health>(out Health healthComponent))
        {
            healthComponent.isInvincible = true; 
            Debug.Log($"{player.name} ahora es invencible.");
        }
        else
        {
            Debug.LogError($"No se encontró un objeto con el tag '{playerTag}' o le falta el componente 'Health'.");
        }
    }
}



