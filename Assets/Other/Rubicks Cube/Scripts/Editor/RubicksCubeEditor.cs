using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Voxelity.Editor;
using System.IO;
using System.Linq;

[CustomEditor(typeof(RubicksCube))]
public class RubicksCubeEditor : UnityEditor.Editor
{
    private RubicksCube targetObj;
    private void OnEnable()
    {
        targetObj = (RubicksCube)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (VoxelityGUI.Button("Create Cube", 30))
        {
            targetObj.SetObject();
        }
        if (VoxelityGUI.Button("Save Cube", 30))
        {
            string path = EditorUtility.OpenFolderPanel("Select target folder", "Assets", "");
            GameObject saved = PrefabUtility.SaveAsPrefabAsset(targetObj.gameObject, Path.Combine(path, targetObj.name + ".prefab"));
            CubeSolution solutionAsset = ScriptableObject.CreateInstance<CubeSolution>();
            solutionAsset.solution = targetObj.GetSolutionMoves;
            saved.GetComponent<RubicksCube>().savedSolution = solutionAsset;

            int assetsIndex = path.IndexOf("Assets/");
            string relativePath = path.Substring(assetsIndex);

            AssetDatabase.CreateAsset(solutionAsset, Path.Combine(relativePath, targetObj.gameObject.name + "Solution.asset"));
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
