using System;
using UnityEditor;
using UnityEngine;

namespace QuickNotes
{
    [CustomEditor(typeof(QNoteSettings))]
    public class QNoteSettingsCustomInspector : Editor
    {
        private QNoteSettings _target;

        private void OnEnable()
        {
            _target = (QNoteSettings)serializedObject.targetObject;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.Space(10, true);
            if(GUILayout.Button("Reset to Default"))
            {
                _target.Font = null;
                _target.FontSize = 14;
                _target.SmartColor = true;
                _target.InverseColor = false;
                _target.WordWrap = true;
                _target.RichText = true;
                _target.TextBackgroundAlpha = 0.32f;
                _target.StartColor = new Color(0.2f, 0.2f, 0.2f, 1);
                _target.BorderPadding = 10;
                EditorUtility.SetDirty(_target);
            }
        }
    }
}