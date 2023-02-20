using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Voxelity.Editor;

namespace Exposable.Demo
{
    [CustomEditor(typeof(GradientToTexture))]
    public class GradientToTextureEditor : Editor
    {
        [SerializeField] private Vector2Int textureSize;
        private GradientToTexture targetObj;

        private void OnEnable()
        {
            targetObj = (GradientToTexture)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (VoxelityGUI.InLineButton("Generate", () =>
            {
                textureSize = EditorGUILayout.Vector2IntField("Texture Size", textureSize,GUILayout.Width(300));
            },true))
            {
                GenerateTexture();
            }
        }
        public void GenerateTexture()
        {
            Texture2D createdTexture = new Texture2D(textureSize.x, textureSize.y);
            EditorUtility.DisplayProgressBar("Generating Texture", "Initializing", 0f);
            int progress = 0;
            bool done = SetTexture(createdTexture, progress);
            while (!done)
            {
                progress += 1;
                EditorUtility.DisplayProgressBar("Generating Texture", "Progress", ((float)progress / (float)textureSize.x)*100f);
                done = SetTexture(createdTexture, progress);
            }
            EditorUtility.ClearProgressBar();
            Debug.Log("Texture Generated Successfully!");
            if (targetObj.imageComponent)
            {
                targetObj.imageComponent.texture = createdTexture;
            }
        }

        private bool SetTexture(Texture2D setted, int xLeng)
        {
            Color col = targetObj.GetColor((float)xLeng / (float)textureSize.x);
            for (int y = 0; y < textureSize.x; y++)
            {
                setted.SetPixel(xLeng, y, col);
            }
            setted.Apply();
            return xLeng >= textureSize.x;
        }
    }
}
