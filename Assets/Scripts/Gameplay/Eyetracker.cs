using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eurovision.Gameplay
{
    public class Eyetracker : MonoBehaviour
    {
        [SerializeField] private bool _useMouse;
        [SerializeField] private Camera _camera;
        [SerializeField] private LayerMask _layerMask;

        public LookObject GetLookTarget()
        {
            Ray ray;

            if (_useMouse)
                ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
            else
                // ray vanuit de camera naar voren
                ray = new Ray(_camera.transform.position, _camera.transform.forward);
                
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask))
            {
                return hit.transform.GetComponent<LookObject>();
            }
            return null;
        }
        
        public LookButton GetLookButton()
        {
            Ray ray;

            if (_useMouse)
                ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
            else
                // ray vanuit de camera naar voren
                ray = new Ray(_camera.transform.position, _camera.transform.forward);
                
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask))
            {
                return hit.transform.GetComponent<LookButton>();
            }
            return null;
        }
    }
}