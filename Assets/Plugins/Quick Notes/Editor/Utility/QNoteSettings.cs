using UnityEditor;
using UnityEngine;

namespace QuickNotes
{
    [CreateAssetMenu(fileName = "QNoteSettings", menuName = "Quick Notes/Settings")]
    public class QNoteSettings : ScriptableObject
    {
        private static QNoteSettings _instance;

        public static QNoteSettings Instance
        {
            get
            {
                if (_instance) return _instance;
                _instance = Resources.Load<QNoteSettings>("QNoteSettings");
                if (_instance) return _instance;
                _instance = CreateInstance<QNoteSettings>();
                AssetDatabase.CreateAsset(_instance, "Assets/Editor/Resources/QNoteSettings.asset");
                AssetDatabase.SaveAssets();
                return _instance;
            }
        }

        #region Text

        public Font Font;
        public int FontSize = 14;
        public bool SmartColor = true;
        public bool InverseColor = false;
        public bool WordWrap = true;
        public bool RichText = true;

        #endregion

        #region Window

        [Range(0,1)]
        public float TextBackgroundAlpha = 0.32f;
        public Color StartColor = new Color()
        {
            r = 0.2f, g = 0.2f, b = 0.2f, a = 1
        };
        public float BorderPadding = 10;

        #endregion
    }
}