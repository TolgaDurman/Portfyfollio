using UnityEngine;

namespace LinkedSO.Demo
{
    public class BoxColorSetter : LinkableItemUser<LinkableColor>
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