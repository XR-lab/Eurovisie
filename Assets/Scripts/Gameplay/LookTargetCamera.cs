using System.Collections;
using System.Collections.Generic;
using Eurovision.Gameplay;
using UnityEngine;
using UnityEngine.VFX;

public class LookTargetCamera : LookObject
{
    private Color _defaultColor;
        private Renderer _renderer;
        private readonly int _baseColor = Shader.PropertyToID("_BaseColor");
        private AudioSource _sound;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _defaultColor = _renderer.material.GetColor(_baseColor);
        _sound = this.GetComponent<AudioSource>();
    }

    public override void SetAsActiveObject()
    {
        _renderer.material.SetColor(_baseColor, Color.blue);
    }

    public override void SetAsInActiveObject()
    {
        _renderer.material.SetColor(_baseColor, _defaultColor);
        GetComponentInChildren<VisualEffect>().SendEvent("Start");
    }

    public override void SetAsGettingLookedAt()
    {
        if (!_sound.isPlaying)
        {
            _sound.Play();
        }
    }

    public override void SetAsNotGettingLookedAt()
    {
        if (_sound.isPlaying)
        {
            _sound.Stop();
        }
    }
}
