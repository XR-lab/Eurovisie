using Boo.Lang;
using Eurovision.Gameplay;
using UnityEngine;

public struct CameraBaviorDTO
{
    public readonly int cameraState;
    public readonly Transform lookObject;
    
    public CameraBaviorDTO(int state, Transform looker)
    {
        this.cameraState = state;
        this.lookObject = looker;
    }
}
