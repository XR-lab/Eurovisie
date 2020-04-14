using Eurovision.Gameplay;
using UnityEngine;
using UnityEngine.VFX;

public class LookTargetCamera : LookObject
{
    private Color _defaultColor;
    private Renderer _renderer;
    private AudioSource _sound;
    private VisualEffect vs;
    
    // public Material _coneMat;
    public bool staticCam;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _sound = GetComponent<AudioSource>();
        vs = GetComponentInChildren<VisualEffect>();
        // Transform[] loop = GetComponentsInChildren<Transform>();
        // foreach (var item in loop)
        // {
        //     if (item.name.Equals("Cone"))
        //     {
        //         _coneMat = item.gameObject.GetComponent<Renderer>().material;
        //         _coneMat.color = Color.red;
        //     }
        // }
    }

    // public override void SetAsActiveObject()
    // {
    //     _coneMat.color = Color.green;
    // }
    //
    // public override void SetAsInActiveObject()
    // {
    //     _coneMat.color = Color.red;
    // }

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
