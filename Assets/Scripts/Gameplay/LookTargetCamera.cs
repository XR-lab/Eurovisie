using System.Collections;
using System.Collections.Generic;
using Eurovision.Gameplay;
using UnityEngine;

public class LookTargetCamera : LookObject
{
    private Color _defaultColor;
        private Renderer _renderer;
        private readonly int _baseColor = Shader.PropertyToID("_BaseColor");

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
            _defaultColor = _renderer.material.GetColor(_baseColor);
        }

    public override void SetAsActiveObject()
    {
        _renderer.material.SetColor(_baseColor, Color.blue);
    }

    public override void SetAsInActiveObject()
    {
        _renderer.material.SetColor(_baseColor, _defaultColor);
    }
}
