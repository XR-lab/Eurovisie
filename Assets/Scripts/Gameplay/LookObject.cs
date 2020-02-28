using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eurovision.Gameplay
{
    public class LookObject : MonoBehaviour
    {
        private Color _defaultColor;
        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();

        }

        private void Start()
        {
            _defaultColor = _renderer.material.GetColor("_BaseColor");
        }

        public void SetAsActiveObject()
        {
            _renderer.material.SetColor("_BaseColor", Color.blue);
        }

        public void SetAsInActiveObject()
        {
            _renderer.material.SetColor("_BaseColor", _defaultColor);
        }
    }
}
