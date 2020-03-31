using Boo.Lang;
using Eurovision.Gameplay;
using UnityEngine;

public struct CameraBaviorDTO
{
    public readonly int cameraState;
    public readonly Transform lookObject;
    public readonly Color targetColor;
    
    public CameraBaviorDTO(int state, Transform looker, Color color)
    {
        this.cameraState = state;
        this.lookObject = looker;
        this.targetColor = color;
    }
}
