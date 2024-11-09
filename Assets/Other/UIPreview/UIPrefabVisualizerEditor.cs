// using UnityEngine;
// using UnityEditor;
//
// [CustomEditor(typeof(PrefabAssetType))]
// [CanEditMultipleObjects]
// public class UIPrefabVisualizerEditor : Editor
// {
//     private GameObject prefab;
//     private Texture2D prefabPreview;
//     private bool showPreview = false;
//
//     public override void OnInspectorGUI()
//     {
//         prefab = (GameObject)target;
//
//         // Check if the selected object is a prefab asset and not an instance in the hierarchy
//         if (!PrefabUtility.IsPartOfPrefabAsset(prefab))
//         {
//             base.OnInspectorGUI();
//             EditorGUILayout.HelpBox("This editor only works with prefab assets in the project.", MessageType.Info);
//             return;
//         }
//
//         base.OnInspectorGUI();
//
//         EditorGUILayout.Space();
//         EditorGUILayout.LabelField("UI Preview", EditorStyles.boldLabel);
//
//         if (GUILayout.Button("Update Preview"))
//         {
//             ShowPrefabPreview();
//         }
//
//         showPreview = EditorGUILayout.Foldout(showPreview, "Show Preview");
//
//         if (showPreview && prefabPreview != null)
//         {
//             GUILayout.Label(prefabPreview, GUILayout.Width(256), GUILayout.Height(256));
//         }
//     }
//
//     private void ShowPrefabPreview()
//     {
//         if (prefab != null)
//         {
//             prefabPreview = AssetPreview.GetAssetPreview(prefab);
//             if (prefabPreview == null)
//             {
//                 // Generate a preview texture if AssetPreview is not available
//                 prefabPreview = new Texture2D(256, 256);
//                 var renderTexture = new RenderTexture(256, 256, 16);
//                 var cameraGO = new GameObject("PreviewCamera");
//                 var camera = cameraGO.AddComponent<Camera>();
//                 camera.targetTexture = renderTexture;
//                 var previewGO = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
//                 previewGO.transform.position = Vector3.zero;
//                 camera.Render();
//                 RenderTexture.active = renderTexture;
//                 prefabPreview.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
//                 prefabPreview.Apply();
//                 DestroyImmediate(cameraGO);
//                 DestroyImmediate(previewGO);
//                 RenderTexture.active = null;
//             }
//         }
//     }
// }
