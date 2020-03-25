using UnityEngine;
using UnityEngine.VFX;

namespace Eurovision.Gameplay
{
    public class LookObject : MonoBehaviour
    {
        public bool lookObject = false;
        private Color _defaultColor;
        private Renderer _renderer;
        private readonly int _baseColor = Shader.PropertyToID("_BaseColor");

        private void Awake()
        {
            
            _renderer = GetComponent<Renderer>();
            if (lookObject == true)
            {
                _defaultColor = _renderer.material.GetColor(_baseColor);
            }
        }

        public void SetAsActiveObject()
        {
            if (lookObject == true)
            {
                _renderer.material.SetColor(_baseColor, Color.blue);
            }
        }

        public void SetAsInActiveObject()
        {
            if (lookObject == true)
            {
                _renderer.material.SetColor(_baseColor, _defaultColor);
                  GetComponentInChildren<VisualEffect>().SendEvent("Start");
            }
           
        }
    }
}
