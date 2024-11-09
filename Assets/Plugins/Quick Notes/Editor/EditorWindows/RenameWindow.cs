using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace QuickNotes
{
    public class RenameWindow : EditorWindow
    {
        private string _newName = "";
        private UnityAction<string> onRename;

        public void OnEnable()
        {
            _newName = "";
        }

        public static void Create(UnityAction<string> onRename)
        {
            RenameWindow window = CreateInstance<RenameWindow>();
            window.titleContent = new GUIContent("Rename");
            window.position = new Rect(Screen.width / 2, Screen.height / 2, 400, 25);
            window.minSize = new Vector2(400, 25);
            window.maxSize = new Vector2(400, 25);
            window.onRename = onRename;
            window.ShowModalUtility();
            window.Focus();
        }

        private void OnGUI()
        {
            _newName = EditorGUILayout.TextField("Name: ",_newName, GUILayout.ExpandWidth(true));

            if (!Event.current.isKey || Event.current.keyCode != KeyCode.Return) return;
            
            onRename?.Invoke(_newName);
            Close();
        }
    }
}