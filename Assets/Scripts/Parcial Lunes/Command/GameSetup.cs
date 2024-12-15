using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class GameSetup : MonoBehaviour
{
    private CommandConsole console;

    void Start()
    {
        console = FindObjectOfType<CommandConsole>();
        
        console.RegisterCommand("make_invincible", new MakePlayerInvincibleCommand());
    }
}

