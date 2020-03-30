using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command<TCommandId, TCommandDataType> : MonoBehaviour
{
    public abstract TCommandId Id { get; }
    public abstract void Execute(TCommandDataType commadData);

    public virtual void Init()
    {
        
    }
}
