using UnityEngine;

namespace RenderToTexture
{
    [RequireComponent(typeof(Camera))]
    [AddComponentMenu("Render Texture")]
    public class RenderToTexture : MonoBehaviour
    {
        public Camera Cam => GetComponent<Camera>();
        public TextureFormat textureFormat = TextureFormat.RGBA32;
        public bool IsRendering;
        public int resWidth = 64;
        public int resHeight = 64;
    }
}