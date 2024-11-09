using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace QuickNotes
{
    public class NoteData
    {
        public string NoteText;
        public QNoteColor SelectedColor;
        public bool IsLocked;
    }

    public class QuickNotesWindow : EditorWindow, IHasCustomMenu
    {
        private NoteData _noteData = new NoteData();
        private bool _initializedPosition = false;
        private Vector2 _scroll;

        [MenuItem("Tools/Quick Notes/New Note #q")]
        public static void ShowWindow()
        {
            var window = OpenUnlockedWindow(Guid.NewGuid().ToString());
            window.InitializePosition();
        }

        [MenuItem("Tools/Quick Notes/Open Note #w")]
        public static void OpenNote()
        {
            string memoPath = Directory.Exists(SaveUtility.MemosPath) ? SaveUtility.MemosPath : Application.dataPath;
            var path = EditorUtility.OpenFilePanel("Open Note", memoPath, "qnote");
            if (string.IsNullOrEmpty(path)) return;
            var window = OpenUnlockedWindow(Path.GetFileNameWithoutExtension(path));
            window.InitializePosition();
        }

        private static QuickNotesWindow OpenUnlockedWindow(string name)
        {
            QuickNotesWindow window = EditorWindow.CreateInstance<QuickNotesWindow>();
            window.name = name;
            window.titleContent =
                new GUIContent(name, EditorGUIUtility.IconContent("d_UnityEditor.ConsoleWindow").image);
            window.Show();
            window.Load(name);
            return window;
        }

        private static QuickNotesWindow OpenLockedWindow(string name)
        {
            QuickNotesWindow window = EditorWindow.CreateInstance<QuickNotesWindow>();
            window.name = name;
            window.titleContent =
                new GUIContent(name, EditorGUIUtility.IconContent("d_UnityEditor.ConsoleWindow").image);
            window._noteData.IsLocked = true;
            window.ShowPopup();
            window.Focus();
            window.ShowNotification(new GUIContent("ALT+L to unlock"), 1f);
            window.Load(name);
            return window;
        }

        private void OnBecameVisible()
        {
            if (string.IsNullOrEmpty(name))
            {
                name = Guid.NewGuid().ToString();
                titleContent =
                    new GUIContent(name, EditorGUIUtility.IconContent("d_UnityEditor.ConsoleWindow").image);
                Debug.Log(name);
            }

            Load();
        }

        private void OnLostFocus()
        {
            if (!EditorUtility.IsDirty(this)) return;
            Save();
            EditorUtility.ClearDirty(this);
        }

        private void InitializePosition()
        {
            if (_initializedPosition) return;
            if (Event.current == null) return;
            var mousePosition = GUIUtility.GUIToScreenPoint(Event.current.mousePosition);
            position = new Rect(mousePosition.x, mousePosition.y, 300, 300);
            _initializedPosition = true;
        }

        private void ShortcutHandler()
        {
            if (Event.current.alt && Event.current.isKey && Event.current.keyCode == KeyCode.Q)
            {
                Close();
                Event.current.Use();
            }

            if (!Event.current.alt || !Event.current.isKey || Event.current.keyCode != KeyCode.L ||
                Event.current.type != EventType.KeyUp) return;

            Save();
            if (_noteData.IsLocked)
            {
                Unlock();
            }
            else
            {
                Lock();
            }

            Event.current.Use();
        }

        private void OnGUI()
        {
            ShortcutHandler();
            DrawContent();
            Repaint();
        }

        private void DrawContent()
        {
            QNoteGUI.DrawBackgroundGUI(position, _noteData.SelectedColor.ToColor());
            using (new EditorGUILayout.VerticalScope())
            {
                EditorGUI.BeginChangeCheck();

                _scroll = EditorGUILayout.BeginScrollView(_scroll);

                Color color = _noteData.SelectedColor.ToColor();
                _noteData.NoteText = QNoteGUI.DrawTextAreaGUI(_noteData?.NoteText, position, color);

                EditorGUILayout.EndScrollView();

                if (!EditorGUI.EndChangeCheck()) return;
                if (!EditorUtility.IsDirty(this))
                    EditorUtility.SetDirty(this);
            }
        }


        public void AddItemsToMenu(GenericMenu menu)
        {
            menu.AddItem(new GUIContent("Note/Lock " + "(Alt + L)"), false, Lock);
            menu.AddItem(new GUIContent("Note/Select Color"), false, OpenColorPicker);
            menu.AddItem(new GUIContent("Note/Rename"), false, Rename);
            menu.AddItem(new GUIContent("Quick Notes Settings"), false, OpenSettings);
            menu.ShowAsContext();
        }

        private void OpenColorPicker()
        {
            ColorPicker.OpenColorPicker(OnColorChanged, _noteData.SelectedColor.ToColor());
        }

        private void OnColorChanged(Color obj)
        {
            _noteData.SelectedColor = obj.ToQNoteColor();

            int size = 12;
            var texture = new Texture2D(size, size);

            for (int i = 0; i < texture.width; i++)
            {
                for (int j = 0; j < texture.height; j++)
                {
                    texture.SetPixel(i, j, _noteData.SelectedColor.ToColor());
                }
            }

            texture.Apply();

            titleContent.image = texture;

            Save();
        }

        private void OpenSettings()
        {
            var settingsObject = QNoteSettings.Instance;
            Selection.activeObject = settingsObject;
            EditorGUIUtility.PingObject(settingsObject);
            EditorApplication.ExecuteMenuItem("Window/General/Inspector");
        }

        private void Rename()
        {
            RenameWindow.Create(newName =>
            {
                if (SaveUtility.Exists(newName))
                {
                    EditorUtility.DisplayDialog("Error", $"A memo with name: {newName} already exists", "OK");
                    return;
                }

                Delete();
                titleContent = new GUIContent(newName,
                    EditorGUIUtility.IconContent("d_UnityEditor.ConsoleWindow").image);
                name = newName;
                Save();
            });
        }

        private void Load(string memoName = null)
        {
            if (string.IsNullOrEmpty(memoName))
                memoName = name;

            _noteData = SaveUtility.LoadMemo(memoName);
            titleContent = new GUIContent(memoName,
                EditorGUIUtility.IconContent("d_UnityEditor.ConsoleWindow").image);
            if (!_noteData.SelectedColor.Equals(QNoteColor.Default))
            {
                OnColorChanged(_noteData.SelectedColor.ToColor());
            }
        }

        private void Save()
        {
            SaveUtility.SaveMemo(name, _noteData);
        }

        private void Delete()
        {
            SaveUtility.DeleteMemo(name);
        }

        private void Unlock()
        {
            string lockedName = name;
            var windowPosition = this.position;
            _noteData.IsLocked = false;
            Save();
            Close();

            var window = OpenUnlockedWindow(lockedName);
            window.position = windowPosition;
        }

        private void Lock()
        {
            var windowPosition = this.position;
            string lockedName = name;
            _noteData.IsLocked = true;
            Save();
            Close();

            var window = OpenLockedWindow(lockedName);
            window.position = windowPosition;
        }
    }
}