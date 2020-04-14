using System.Collections.Generic;
using Eurovision;
using Eurovision.Input;
using UnityEngine;

public class TimelineEffectsManager : MonoBehaviour
{
    // ============================================================================================= 'Private' Variables
    [SerializeField] private RandomButtonPresser randomAiScript;
    [SerializeField] private Effect danceCircle;
    [SerializeField] private Effect fire;
    [SerializeField] private Effect laser;
    [SerializeField] private Effect smoke;
    
    // =============================================================================================== Private Variables
    private Dictionary<EffectEnum.EffectEnums, Effect> _effectDictionary = new Dictionary<EffectEnum.EffectEnums, Effect>();
    
    // =========================================================================================================== Start
    private void Start()
    {
        _effectDictionary.Add(EffectEnum.EffectEnums.DanceCircle, danceCircle);
        _effectDictionary.Add(EffectEnum.EffectEnums.Fire, fire);
        _effectDictionary.Add(EffectEnum.EffectEnums.Laser, laser);
        _effectDictionary.Add(EffectEnum.EffectEnums.Smoke, smoke);
    }

    // ========================================================================================= Random Ai (dis/en)abler
    public void RandomAiController(bool enable)
    {
        if(enable) randomAiScript.StartAI();
        else if(!enable) randomAiScript.StopEffects();
    }
    
    // ==================================================================================================== Start Effect
    public void StartEffect(EffectEnum.EffectEnums targetedEffectKey)
    {
        print(targetedEffectKey.ToString());
        Effect targetEffect;
        _effectDictionary.TryGetValue(targetedEffectKey, out targetEffect);
        targetEffect.OnEffectStart();
    }
    
    // ===================================================================================================== Stop Effect
    public void StopEffect(EffectEnum.EffectEnums targetedEffectKey)
    {
        Effect targetEffect;
        _effectDictionary.TryGetValue(targetedEffectKey, out targetEffect);
        targetEffect.OnEffectStop();
    }
}
