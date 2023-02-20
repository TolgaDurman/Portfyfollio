using UnityEngine;

namespace Exposable.Demo
{
    public class BoxColorSetter : ExposedItemUser<ExposedColor>
    {
        private MeshRenderer _meshRenderer;
        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }
        private void OnEnable()
        {
            myObject.GiveColor += GetColor;
        }
        public void GetColor(Color sharedColor)
        {
            _meshRenderer.material.color = sharedColor;
        }
        private void OnDisable()
        {
            myObject.GiveColor -= GetColor;
        }
    }
}