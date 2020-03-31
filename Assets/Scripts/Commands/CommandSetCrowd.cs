using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using Random = UnityEngine.Random;

public class CommandSetCrowd : Command<BehaviorIds, CrowdBehaviorDTO>
{
    public override BehaviorIds Id => BehaviorIds.Crowd;
    public float offset;
    
    private AnimatorOverrideController[] _setAnimators;
    private Animator[] _animators;
    private AnimatorStateInfo _current;
    
    private void Start()
    {
        _setAnimators = Resources.LoadAll<AnimatorOverrideController>("Animators");
        _animators = this.GetComponentsInChildren<Animator>();
        _current = _animators[1].GetCurrentAnimatorStateInfo(0);
        for (int i = 0; i < _animators.Length; i++)
        {
            _animators[i].runtimeAnimatorController = _setAnimators[Random.Range(0,3)];
            _animators[i].Play(_animators[i].GetCurrentAnimatorStateInfo(0).shortNameHash, 0, Random.Range(0f,offset));
        }
        //Debug.Log(_setAnimators.Length + "Hello");
    }

    public override void Execute(CrowdBehaviorDTO commadData)
    {
        for (int i = 0; i < _animators.Length; i++)
        {
            _animators[i].SetFloat("Hype", commadData.crowdHype);
           // _animators[i].SetFloat("Offset",Random.Range(0f, offset));
        }
        if (_current.shortNameHash != _animators[1].GetCurrentAnimatorStateInfo(0).shortNameHash)
        {
            for (int i = 0; i < _animators.Length; i++)
            {
                _animators[i].Play(_animators[i].GetCurrentAnimatorStateInfo(0).shortNameHash, 0, Random.Range(0f,offset));
            }
        }
        _current = _animators[1].GetCurrentAnimatorStateInfo(0);
    }
}
