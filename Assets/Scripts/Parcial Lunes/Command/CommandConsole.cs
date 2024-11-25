using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections.Generic;
using UnityEngine;

public class CommandConsole : MonoBehaviour
{
    private Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

    public void RegisterCommand(string commandName, ICommand command)
    {
        if (!commands.ContainsKey(commandName))
        {
            commands.Add(commandName, command);
        }
    }

    public void ExecuteCommand(string commandName)
    {
        if (commands.TryGetValue(commandName, out ICommand command))
        {
            command.Execute();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            ExecuteCommand("make_invincible");
        }
    }

}

