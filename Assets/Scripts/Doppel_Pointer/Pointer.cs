using System;
using System.Collections;
using System.Collections.Generic;
using Eurovision.Gameplay;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

// This script requires the pointer image to have it's X-axis pivot at 0.
// This script requires the pointer to point to the right.
// Add "Parent_Pointer" prefrab to VR_UI Gameobject.
public class Pointer : MonoBehaviour {
    // Camera.
    [SerializeField] private Camera _camera;
    
    // Target.
    [SerializeField] private GameObject _target;
    private Vector3 _targetPosition;
    
    // Pivot.
    [SerializeField] private GameObject _pivot;

    // Pointer.
    [SerializeField] private RectTransform _pointerRect;
    [SerializeField] private Image _pointerSprite;
    [SerializeField] private float _alpha = 0;
    [SerializeField] private float _fadeSpeed = 1.5f;

    // References.
    [SerializeField] private TaskGenerator _taskGenerator;


    private void Start() {
        ReversePointer();
        SetTarget(_target);
        _taskGenerator.NewTarget += SetTarget;
    }

    private void Update() {
        RotatePointer();
        // PositionPointer();
        FadePointer();
    }

    private void SetTarget(GameObject target) {
        _target = target;
        GameObject lookObj = _target.GetComponentInChildren<CameraLensPosition>().gameObject;
        _targetPosition = lookObj.transform.position;
        _target = lookObj;
        _alpha = 0f;
    }

    private void RotatePointer() {
        Vector3 toPosition = _camera.WorldToScreenPoint(_targetPosition);
        Vector3 fromPosition = _camera.WorldToScreenPoint(_pointerRect.transform.position);
        Vector3 direction = (fromPosition - toPosition).normalized;
        float angle = GetAngleFromVector(direction);

        _pointerRect.localEulerAngles = new Vector3(0, 0, angle);
        // DistanceBetween(toPosition, fromPosition);
    }

    private void PositionPointer() {
        Vector3 point = _pivot.transform.position;
        Vector3 axis = Vector3.forward;
        float angle = 90 * Time.deltaTime;
        
        _pointerRect.RotateAround(point, axis, angle);
    }
    

    private void DistanceBetween(Vector3 to, Vector3 from) {
        to = to.normalized;
        from = from.normalized;
        float distance = Vector2.Distance(to, from);
    }

    private void FadePointerIn() {
        if (_alpha >= 1)
        {
            return;
        }
        
        _alpha += _fadeSpeed * Time.deltaTime;
        SetPointerAlpha(_alpha);
    }

    public void FadePointerOut() {
        if (_alpha < 0)
        {
            return;
        }
        
        _alpha -= _fadeSpeed * Time.deltaTime;
        SetPointerAlpha(_alpha);
    }

    private void FadePointer() {
        Ray ray = new Ray(_pointerRect.transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject obj = hit.collider.gameObject;
            
            if (obj == _target) {
                FadePointerOut();
                return;
            }
            FadePointerIn();
        }
    }
    
    private void SetPointerAlpha(float alpha) {
        _pointerSprite.color = new Color(_pointerSprite.color.r, _pointerSprite.color.g, _pointerSprite.color.b, alpha);
    }

    private float GetAngleFromVector(Vector3 dir) {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }
    
    private void ReversePointer() {
        _pointerRect.localScale *= -1;
    }

    private void OnDestroy() {
        _taskGenerator.NewTarget -= SetTarget;
    }
}
