using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eurovision.Gameplay
{
    public class Eyetracker : MonoBehaviour
    {
        [SerializeField] private bool _useMouse;
        [SerializeField] private Camera _vrCamera;
        [SerializeField] private LayerMask _layerMask;

        public LookObject GetLookTarget()
        {
            Ray ray;

            if (_useMouse)
                ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
            else
                ray = new Ray(_vrCamera.transform.position, _vrCamera.transform.forward);
                
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask))
            {
                return hit.transform.GetComponent<LookObject>();
            }
            return null;
        }
    }
}