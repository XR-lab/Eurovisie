using UnityEngine;

public class FollowObject : MonoBehaviour
{
    // ============================================================================================= "private" variables
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    // ========================================================================================================== Update
    void Update()
    {
        transform.position = target.position + offset;
    }
}
