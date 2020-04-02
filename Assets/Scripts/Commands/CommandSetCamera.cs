using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandSetCamera : Command<BehaviorIds, CameraBaviorDTO>
{ 
    public override BehaviorIds Id => BehaviorIds.Camera;
    public Color color;
   
    [SerializeField] private float _speed;
    [SerializeField] private float _returnSpeed;
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
        Debug.Log("Call");
    }
    
    private IEnumerator MoveStarter(CameraBaviorDTO commandData)
    {
        Debug.Log("start");
        Vector3 _tempVec = commandData.lookObject.position;
        Quaternion _quaternion = commandData.lookObject.rotation;
        
        while (commandData.lookObject.GetComponent<Renderer>().material.GetColor("_BaseColor") == color)
        {
            Debug.Log("Here");
            _movements[commandData.cameraState].ObjectMover(commandData.lookObject, _distance, _maxDistance, _tempVec);
            //yield return new WaitForSeconds(_speed);
            yield return new WaitForSecondsRealtime(Time.deltaTime * _speed);
        }
        Debug.Log(Vector3.Distance(commandData.lookObject.position, _tempVec));
        while (Vector3.Distance(commandData.lookObject.position, _tempVec) > 0.2f)
        {
            commandData.lookObject.LookAt(_tempVec);
            commandData.lookObject.Translate(transform.forward * Time.deltaTime);
            yield return new WaitForSecondsRealtime(Time.deltaTime * _returnSpeed);
        }
        commandData.lookObject.position = _tempVec;
        commandData.lookObject.rotation = _quaternion;
    }
}
