using System;
using System.Collections;
using System.Collections.Generic;
using Eurovision.Gameplay;
using UnityEngine;

public class ActiveCameraEffect : MonoBehaviour {
    [Tooltip("Drag all look object camera rigs here.")]
    [SerializeField] private GameObject[] _allCameraRigs;
    [Tooltip("Drag default camera material here.")]
    [SerializeField] private Material _defaultCameraMaterial;
    [Tooltip("Drag active camera material here.")]
    [SerializeField] private Material _activeCameraMaterial;
    [Tooltip("Drag active camera particle prefab here.")]
    [SerializeField] private GameObject _particlePrefab;
    private List<ParticleSystem> _particleSystems;
    private GameObject _currentTarget;
    [Tooltip("Enter name of camera rig object here.")]
    [SerializeField] private string _objectName;
    
    // Dictionaries.
    private Dictionary<GameObject, Material> _cameraMaterialMap;
    private Dictionary<GameObject, ParticleSystem[]> _cameraParticleMap;
    
    // References.
    [Tooltip("Drag @TaskSystem here.")]
    [SerializeField] private TaskGenerator _taskGenerator;

    private void Start() {
        InitCameraMaterialMap();
        InitCameraParticleMap();
        InstantiateParticles();
        
        // Subscribe.
        _taskGenerator.NewTarget += SwitchActiveTarget;

        for (int i = 0; i < _allCameraRigs.Length; i++) {
            SetCameraInactive(_allCameraRigs[i]);
            SetCameraParticlesInactive(_allCameraRigs[i]);
        }
    }

    private void InstantiateParticles() {
        for (int i = 0; i < _allCameraRigs.Length; i++) {
            GameObject particle = Instantiate(_particlePrefab, _allCameraRigs[i].transform);

            ParticleSystem[] ps = particle.GetComponentsInChildren<ParticleSystem>();
            AddParticleToMap(_allCameraRigs[i], ps);
            AddMaterialToMap(_allCameraRigs[i], _defaultCameraMaterial);
        }
    }

    private void InitCameraMaterialMap() {
        _cameraMaterialMap = new Dictionary<GameObject, Material>();
    }

    private void InitCameraParticleMap() {
        _cameraParticleMap = new Dictionary<GameObject, ParticleSystem[]>();
    }

    private void AddParticleToMap(GameObject obj, ParticleSystem[] ps) {
        _cameraParticleMap.Add(obj, ps);
    }

    private void AddMaterialToMap(GameObject obj, Material mat) {
        _cameraMaterialMap.Add(obj, mat);
    }

    private void SwitchCameraMaterial(GameObject cam, Material mat) {
        _cameraMaterialMap[cam] = mat;
        for (int i = 0; i < _allCameraRigs.Length; i++) {
            if (_allCameraRigs[i] == cam) {
                MeshRenderer renderer = cam.GetComponent<MeshRenderer>();
                renderer.material = mat;
            }
        }
    }

    private void SwitchActiveTarget(GameObject obj) {
        if (_currentTarget != null) {
            GameObject previousTarget = null;
            previousTarget = _currentTarget;
            SetCameraInactive(previousTarget);
            SetCameraParticlesInactive(previousTarget);
        }
        _currentTarget = obj;
        SetCameraActive(_currentTarget);
        SetCameraParticlesActive(_currentTarget);
    }
    
    private void SetCameraActive(GameObject obj) {
        MeshRenderer[] renderers = obj.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < renderers.Length; i++) {
            if (renderers[i].name == _objectName) {
                GameObject cam = renderers[i].gameObject;
                SwitchCameraMaterial(cam, _activeCameraMaterial);
            }
        }
    }

    private void SetCameraInactive(GameObject obj) {
        MeshRenderer[] renderers = obj.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < renderers.Length; i++) {
            if (renderers[i].name == _objectName) {
                GameObject cam = renderers[i].gameObject;
                SwitchCameraMaterial(cam, _defaultCameraMaterial);
            }
        }
    }

    private void SetCameraParticlesActive(GameObject obj) {
        ParticleSystem[] ps = obj.GetComponentsInChildren<ParticleSystem>();

        foreach (var system in ps) {
            system.Play();
        }
    }

    private void SetCameraParticlesInactive(GameObject obj) {
        ParticleSystem[] ps = obj.GetComponentsInChildren<ParticleSystem>();

        foreach (var system in ps) {
            system.Stop();
        }
    }

    private void OnDestroy() {
        _taskGenerator.NewTarget -= SetCameraActive;
    }
}
