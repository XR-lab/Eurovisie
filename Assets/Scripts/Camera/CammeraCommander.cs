using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CammeraCommander : Commander<BehaviorIds, CameraBaviorDTO>
{
    [SerializeField] private bool getCommandsAtStart = true;
    void Start()
    {
        if(getCommandsAtStart)
            InitializeCommands();
    }

    public void InitializeCommands()
    {
        var allCommands = GetComponents<Command<BehaviorIds, CameraBaviorDTO>>();
        foreach (var command in allCommands)
        {
            AddCommand(command.Id, command);
            command.Init();
        }
    }
}