﻿using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    public abstract void ObjectMover(Transform target, float distance, float maxDistance, Vector3 startPos);

    public virtual void Moving(Vector3 target, Transform origin)
    {
        origin.LookAt(target);
        origin.Translate(transform.forward*Time.deltaTime);
    }
}
