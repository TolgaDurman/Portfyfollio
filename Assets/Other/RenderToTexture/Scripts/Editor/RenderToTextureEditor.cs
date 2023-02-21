using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Voxelity.Extensions;

namespace RenderToTexture
{
    [CustomEditor(typeof(RenderToTexture))]
    public class RenderToTextureEditor : Editor
    {
        private RenderToTexture targetObj;
        private bool isRendering;

        public void OnEnable()
        {
            targetObj = (RenderToTexture)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUI.BeginDisabledGroup(isRendering); // Disable the button during rendering
            if (GUILayout.Button("Render"))
            {
                Render();
            }
            EditorGUI.EndDisabledGroup();
        }

        private void Render()
        {
            string storePath = EditorUtility.SaveFilePanel("Save Screenshot", "Assets/", "ScreenShot.png", "png");
            if (storePath != "")
            {
                isRendering = true;
                targetObj.IsRendering = true;

                RenderTexture rt = new RenderTexture(targetObj.resWidth, targetObj.resHeight, 24);
                targetObj.Cam.targetTexture = rt;
                Texture2D screenShot = new Texture2D(targetObj.resWidth, targetObj.resHeight, targetObj.textureFormat, false);

                // Show progress bar
                float progress = 0f;
                EditorUtility.DisplayProgressBar("Rendering", "Rendering scene...", progress);

                // Start rendering
                targetObj.Cam.Render();

                // Update progress and show in progress bar
                progress = 0.5f;
                EditorUtility.DisplayProgressBar("Rendering", "Converting to texture...", progress);

                RenderTexture.active = rt;
                screenShot.ReadPixels(new Rect(0, 0, targetObj.resWidth, targetObj.resHeight), 0, 0);
                targetObj.Cam.targetTexture = null;
                RenderTexture.active = null;

                // Update progress and show in progress bar
                progress = 0.8f;
                EditorUtility.DisplayProgressBar("Rendering", "Saving file...", progress);

                rt.Release();
                DestroyImmediate(rt);

                UnityEditor.EditorApplication.delayCall += () =>
                {
                    byte[] bytes = screenShot.EncodeToPNG();
                    System.IO.File.WriteAllBytes(storePath, bytes);
                    Debug.Log("Render successful!".Colorize(Color.green));
                    AssetDatabase.Refresh();

                    // End rendering
                    isRendering = false;
                    targetObj.IsRendering = false;

                    // Close progress bar
                    EditorUtility.ClearProgressBar();
                };
            }
        }
    }
}
