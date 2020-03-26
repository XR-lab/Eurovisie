using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander<TCommandID, TCommandDataType> : MonoBehaviour
{
    private readonly Dictionary<TCommandID, Command<TCommandID,TCommandDataType>> commands = new Dictionary<TCommandID, Command<TCommandID,TCommandDataType>>();

    public void Apply(TCommandID commandId, TCommandDataType commandData)
    {
        if(!commands.ContainsKey((commandId)))
            return;

        commands[commandId].Execute(commandData);
    }

    public void AddCommand(TCommandID commandId, Command<TCommandID, TCommandDataType> newCommand)
    {
        commands.Add(commandId,newCommand);
        newCommand.Init();
    }

    public void RemoveCommand(TCommandID commandId)
    {
        commands.Remove(commandId);
    }
}
