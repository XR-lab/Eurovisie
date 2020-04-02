using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : Mover
{
    private bool _returning = false;
    public override void ObjectMover(Transform target, float distance, float maxDistance, Vector3 startPos)
    {
        if (target.position.y <= startPos.y + maxDistance && !_returning)
        {
            _returning = false;
            Moving(new Vector3(startPos.x,startPos.y + maxDistance,startPos.z), target);
        }
        else if(target.position.y > startPos.y + maxDistance||_returning)
        {
            _returning = true;
            Moving(startPos,target);
            if (target.position.y <= startPos.y)
            {
                _returning = false;
            }
        }
    }
}
