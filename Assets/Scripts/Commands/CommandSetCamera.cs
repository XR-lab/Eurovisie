using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandSetCamera : Command<BehaviorIds, CameraBaviorDTO>
{ 
    public override BehaviorIds Id => BehaviorIds.Camera;
    public Color color;

   /* private class StateAction
    {
        public Func<bool, float, float, float> MayMove;
        zzzz
    }

    Dictionary<int, StateAction> stateActions = new Dictionary<int, StateAction>();*/
   
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;
    [SerializeField] private float _maxDistance;
    private Dictionary<int, Mover> _movements = new Dictionary<int, Mover>();

    private void Start()
    {
        var tempList = gameObject.GetComponents<Mover>();
        for (int i = 0; i < tempList.Length; i++)
        {
            _movements.Add(i+1,tempList[i]);
        }
    }

    public override void Execute(CameraBaviorDTO commandData)
    {
        if (!_movements.ContainsKey(commandData.cameraState))
            return;

        StartCoroutine(MoveStarter(commandData));
    }
    
    private IEnumerator MoveStarter(CameraBaviorDTO commandData)
    {
        Vector3 _tempVec = commandData.lookObject.position;
        
        while (commandData.lookObject.GetComponent<Renderer>().material.GetColor("_BaseColor") == color)
        {
            _movements[commandData.cameraState].ObjectMover(commandData.lookObject, _distance, _maxDistance, _tempVec);
            yield return new WaitForSeconds(_speed);
        }
        commandData.lookObject.position = _tempVec;
    }
}
