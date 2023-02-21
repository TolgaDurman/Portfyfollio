using UnityEngine;
using UnityEngine.UI;
using Voxelity.Extensions;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace LinkedSO.Demo
{
    public class GradientToTexture : MonoBehaviour
    {
        public RawImage imageComponent;
        [SerializeField]private Gradient gradient;



        public Color GetColor(float value)
        {
            return gradient.Evaluate(value).WithA(255f);
        }
    }
}
