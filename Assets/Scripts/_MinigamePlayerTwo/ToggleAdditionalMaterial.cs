using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAdditionalMaterial : MonoBehaviour
{
    public void ToggleGameObject(bool x)
    {
        gameObject.SetActive(x);
    }
}