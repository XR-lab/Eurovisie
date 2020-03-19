using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRenderer : MonoBehaviour
{
    // Components.
    private MeshRenderer rend;

    private void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    // Sets the color of the button.
    public void SetColor(Color color)
    {
        rend.material.SetColor("_BaseColor", color);
    }
    
    // Returns this button mesh renderer.
    public MeshRenderer GetMeshRenderer()
    {
        return rend;
    }
}
