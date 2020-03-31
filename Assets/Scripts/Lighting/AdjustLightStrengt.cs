using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustLightStrengt : MonoBehaviour
{
    // ==============================================================================================='public' variables
    [SerializeField] private Light[] lights;
    [SerializeField] private float middleGround;
    [SerializeField] private float multiplier;

    // =============================================================================================== private variables
    private float[] _lightBaseStrenght;

    private void Awake()
    {
        _lightBaseStrenght = new float[lights.Length];
        for (int i = 0; i < lights.Length; i++)
        {
            _lightBaseStrenght[i] = lights[i].intensity;
        }

    }

    //===================================================================================================== Change Value
    public void ChangeLightValue(float strenght)
    {
        
        float _strenght;
        for (int i = 0; i < lights.Length; i++)
        {
            _strenght = ((strenght / middleGround) + 1) * _lightBaseStrenght[i];
            lights[i].intensity = _strenght;
        }
    }
}
