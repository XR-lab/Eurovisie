using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandSetCamera : Command<BehaviorIds, CameraBaviorDTO>
{
    public override BehaviorIds Id => BehaviorIds.Camera;

    private bool _moving;
    private Transform[] _transforms;

    private void Start()
    {
        _transforms = GetComponentsInChildren<Transform>();
    }

    public override void Execute(CameraBaviorDTO commadData)
    {
        StartCoroutine(MoveStarter(commadData));
    }

    private IEnumerator MoveStarter(CameraBaviorDTO commandData)
    {
        while (_moving)
        {
            switch (commandData.cameraState)
            {
                case 1:
                    commandData.lookObject.gameObject.transform.position = Vector3.left;
                    break;
                case 2:
                    commandData.lookObject.gameObject.transform.position = Vector3.right;
                    break;
                case 3:
                    commandData.lookObject.gameObject.transform.position = Vector3.up;
                    break;
                case 4:
                    //commandData.lookObject.gameObject.transform.position = Vector3.down;
                    mover(commandData, Vector3.down);
                    break;
            }
            yield return new WaitForEndOfFrame();
        }
        StopCoroutine(MoveStarter(commandData));
    }

    private void mover(CameraBaviorDTO commandData, Vector3 direction)
    {
        commandData.lookObject.gameObject.transform.position = direction;
    }
}
