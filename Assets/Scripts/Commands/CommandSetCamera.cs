using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandSetCamera : Command<BehaviorIds, CameraBaviorDTO>
{
    public override BehaviorIds Id => BehaviorIds.Camera;

    [SerializeField] private float _speed;
    [SerializeField] private float _distance;
    [SerializeField] private float _maxDistance;
    //private Vector3 _tempVec;
    public override void Execute(CameraBaviorDTO commadData)
    {
        StartCoroutine(MoveStarter(commadData));
    }
    private IEnumerator MoveStarter(CameraBaviorDTO commandData)
    {
        bool _moving = true;
        Vector3 _tempVec = commandData.lookObject.position;
        while (_moving)
        {
            switch (commandData.cameraState)
            {
                case 1:
                    if (commandData.lookObject.position.x <= _tempVec.x - _maxDistance)
                    {
                        _moving = false;
                    }
                    else
                    {
                        mover(commandData, new Vector3(commandData.lookObject.position.x - _distance, _tempVec.y,_tempVec.z));
                    }
                    break;
                case 2:
                    if (commandData.lookObject.position.x >= _tempVec.x + _maxDistance)
                    {
                        _moving = false;
                    }
                    else
                    {
                        mover(commandData,new Vector3(commandData.lookObject.position.x + _distance, _tempVec.y,_tempVec.z));
                    }
                    break;
                case 3:
                    if (commandData.lookObject.position.y >= _tempVec.y + _maxDistance)
                    {
                        _moving = false;
                    }
                    else
                    {
                        mover(commandData, new Vector3(_tempVec.x, commandData.lookObject.position.y + _distance,_tempVec.z));
                    }
                    break;
                case 4:
                    if (commandData.lookObject.position.y <= _tempVec.y - _maxDistance)
                    {
                        _moving = false;
                    }
                    else
                    {
                        mover(commandData, new Vector3(_tempVec.x, commandData.lookObject.position.y - _distance,_tempVec.z));
                    }
                    break;
                default:
                    Debug.Log("Quit");
                    _moving = false;
                    break;
            }
            yield return new WaitForSeconds(_speed);
        }
        commandData.lookObject.position = _tempVec;
       // _tempVec = new Vector3(0,0,0);
        StopCoroutine(MoveStarter(commandData));
    }

    private void mover(CameraBaviorDTO commandData, Vector3 direction)
    {
        Debug.Log("Start");
        commandData.lookObject.position = direction;
    }
}
