using UnityEngine;

namespace Eurovision.Gameplay
{
    public class LookObject : MonoBehaviour
    {
        private Color _defaultColor;
        private Renderer _renderer;
        private readonly int _baseColor = Shader.PropertyToID("_BaseColor");

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
            _defaultColor = _renderer.material.GetColor(_baseColor);
        }

        public void SetAsActiveObject()
        {
            _renderer.material.SetColor(_baseColor, Color.blue);
        }

        public void SetAsInActiveObject()
        {
            _renderer.material.SetColor(_baseColor, _defaultColor);
        }
    }
}
