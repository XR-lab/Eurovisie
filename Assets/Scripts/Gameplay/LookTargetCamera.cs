using Eurovision.Gameplay;
using UnityEngine;
using UnityEngine.VFX;

public class LookTargetCamera : LookObject
{
    private Color _defaultColor;
    private Renderer _renderer;
    private readonly int _baseColor = Shader.PropertyToID("_BaseColor");
    private AudioSource _sound;
    private VisualEffect vs;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _defaultColor = _renderer.material.GetColor(_baseColor);
        _sound = GetComponent<AudioSource>();
        vs = GetComponentInChildren<VisualEffect>();
    }

    public override void SetAsActiveObject()
    {
        _renderer.material.SetColor(_baseColor, Color.white);
    }

    public override void SetAsInActiveObject()
    {
        _renderer.material.SetColor(_baseColor, _defaultColor);
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

    public override void PlayEffect()
    {
        vs.SendEvent("Start");
    }
}
