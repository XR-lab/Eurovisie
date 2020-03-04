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

        private GameObject _visionCube;

        private void Start()
        {
            _visionCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _visionCube.transform.SetParent(transform);
            _visionCube.transform.localScale /= 4f;
            _visionCube.SetActive(false);
        }

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
                _visionCube.SetActive(true);
                _visionCube.transform.position = hit.point;
                return hit.transform.GetComponent<LookObject>();
            }
            else
            {
                _visionCube.SetActive(false);
            }

            return null;
        }
    }
}