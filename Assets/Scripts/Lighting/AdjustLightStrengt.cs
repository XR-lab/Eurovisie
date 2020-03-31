﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustLightStrengt : MonoBehaviour
{
    // ==============================================================================================='public' variables
    [SerializeField] private Light[] lights;
    [SerializeField] private float middleGround;
    [SerializeField] private float multiplier;
    [SerializeField] private Transform[] cones;

    // =============================================================================================== private variables
    private float[] _lightBaseStrenght;
    private Vector3[] _baseConeScale;
    

    private void Awake()
    {
        _lightBaseStrenght = new float[lights.Length];
        for (int i = 0; i < lights.Length; i++)
        {
            _lightBaseStrenght[i] = lights[i].intensity;
        }

        _baseConeScale = new Vector3[cones.Length];
        for (int i = 0; i < cones.Length; i++)
        {
            _baseConeScale[i] = cones[i].localScale;
        }
    }

    //===================================================================================================== Change Value
    public void ChangeLightValue(float strenght)
    {
        print(strenght);
        float _strenght;
        for (int i = 0; i < lights.Length; i++)
        {
            _strenght = (strenght / middleGround) + 1;
            lights[i].intensity = _strenght * _lightBaseStrenght[i];
            
            Vector3 _scale = ((_strenght/4) * _baseConeScale[i]) + _baseConeScale[i];
            _scale.y = _baseConeScale[i].y;
            cones[i].localScale = _scale;
        }
    }
}
