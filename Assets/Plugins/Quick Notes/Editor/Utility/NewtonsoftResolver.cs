using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;

namespace QuickNotes
{
    public class NewtonsoftResolver
    {
#if !NEWTONSOFT_JSON_NUGET
        private const string PackName = "com.unity.nuget.newtonsoft-json";
        private static AddRequest addRequest;

        [InitializeOnLoadMethod]
        public static void InitializeNewtonsoftJsonPackage()
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode) return;

            if (EditorApplication.isCompiling)
            {
                EditorApplication.delayCall += InitializeNewtonsoftJsonPackage;
                return;
            }

            // Add the package to the project by name
            addRequest = Client.Add(PackName);

            EditorApplication.update += ProgressCheck;
        }

        private static void ProgressCheck()
        {
            if (addRequest.IsCompleted)
            {
                if (addRequest.Status == StatusCode.Success)
                {
                    UnityEngine.Debug.Log($"Successfully installed: {addRequest.Result.packageId}");
                }
                else if (addRequest.Status >= StatusCode.Failure)
                {
                    UnityEngine.Debug.LogError($"Failed to install package: {addRequest.Error.message}");
                }
                EditorApplication.update -= ProgressCheck;
            }
        }
#endif
    }
}