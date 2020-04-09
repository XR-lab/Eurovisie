using UnityEngine;

public class EffectSignalReciever : MonoBehaviour
{
    // =============================================================================================== Private Variables
    private TimelineEffectsManager _manager;
    
    // =========================================================================================================== Start
    private void Start()
    {
        _manager = GetComponent<TimelineEffectsManager>();
    }
    
    // ================================================================================================= Effect starters
    public void StartFire(bool start) // ========================================================================== Fire
    {
        if(start)_manager.StartEffect(EffectEnum.EffectEnums.Fire);
        else _manager.StopEffect(EffectEnum.EffectEnums.Fire);
    }

    public void StartDanceCircle(bool start) // =========================================================== Dance Circle
    {
        if(start)_manager.StartEffect(EffectEnum.EffectEnums.DanceCircle);
        else _manager.StopEffect(EffectEnum.EffectEnums.DanceCircle);
    }
    
    public void StartLaser(bool start) // ======================================================================== Laser
    {
        if(start)_manager.StartEffect(EffectEnum.EffectEnums.Laser);
        else _manager.StopEffect(EffectEnum.EffectEnums.Laser);
    }
    
    public void StartSmoke(bool start) // ======================================================================== Smoke
    {
        if(start)_manager.StartEffect(EffectEnum.EffectEnums.Smoke);
        else _manager.StopEffect(EffectEnum.EffectEnums.Smoke);
    }
}
