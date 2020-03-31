using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class CrowdCommander :Commander<BehaviorIds, CrowdBehaviorDTO>
{
    [SerializeField] private bool getCommandsAtStart = true;
    void Start()
    {
        if(getCommandsAtStart)
            InitializeCommands();
    }

    public void InitializeCommands()
    {
        var allCommands = GetComponents<Command<BehaviorIds, CrowdBehaviorDTO>>();
        foreach (var command in allCommands)
        {
            AddCommand(command.Id, command);
            command.Init();
        }
    }
}
