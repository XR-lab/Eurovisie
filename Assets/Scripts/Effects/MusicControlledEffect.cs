using UnityEngine;

public class MusicControlledEffect : MonoBehaviour
{
    // ==============================================================================================='public' variables
    [SerializeField] private ParticleSystem effect;
    
    // =============================================================================================== private variables 
    private bool _isActive = false;
    
    // ==================================================================================================== start effect
    public void StartEffect()
    {
        if (_isActive) return;

        _isActive = true;
        effect.Play();
    }
    
    // ===================================================================================================== stop effect
    public void StopEffect()
    {
        if (!_isActive) return;

        _isActive = false;
        effect.Stop();
    }
}
