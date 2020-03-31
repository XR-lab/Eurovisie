using UnityEngine;

public class FollowObject : MonoBehaviour
{
    // ============================================================================================= "private" variables
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private bool dontFollowX, dontFollowY, dontFollowZ;

    // ========================================================================================================== Update
    void Update()
    {
        Vector3 targetPos = new Vector3();
        if(!dontFollowX){targetPos.x = target.position.x;} else targetPos.x = transform.position.x;
        if(!dontFollowY){targetPos.y = target.position.y;} else targetPos.y = transform.position.y;
        if(!dontFollowZ){targetPos.z = target.position.z;} else targetPos.z = transform.position.z;
        transform.position = targetPos + offset;
    }
}
