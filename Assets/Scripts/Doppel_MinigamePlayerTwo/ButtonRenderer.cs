using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRenderer : MonoBehaviour
{
    // Components.
    [SerializeField] private MeshRenderer buttonTopRenderer;


    // Sets the color of the button.
    public void SetMaterial(Material mat)
    {
        buttonTopRenderer.material = mat;
    }
    
    // Returns this button mesh renderer.
    public MeshRenderer GetMeshRenderer()
    {
        return buttonTopRenderer;
    }
    
}
