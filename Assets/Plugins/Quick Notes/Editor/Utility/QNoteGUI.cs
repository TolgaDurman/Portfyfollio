using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QuickNotes
{
    internal static class QNoteGUI
    {
        public static void DrawBackgroundGUI(Rect window, Color color)
        {
            // Use the window rect to draw the background directly
            EditorGUI.DrawRect(new Rect(0, 0, window.width, window.height), color);
        }

        public static string DrawTextAreaGUI(string current, Rect windowRect, Color backgroundColor)
        {
            var padding = QNoteSettings.Instance.BorderPadding;
            var textBackgroundColor = backgroundColor;
            textBackgroundColor.a = QNoteSettings.Instance.TextBackgroundAlpha;

            GUI.backgroundColor = textBackgroundColor;

            var style = GetTextAreaStyle(textBackgroundColor);

            List<GUILayoutOption> options = new List<GUILayoutOption>
            {
                GUILayout.ExpandHeight(true),
                GUILayout.ExpandWidth(true)
            };

            if (!QNoteSettings.Instance.WordWrap)
            {
                options.Add(GUILayout.MaxWidth(windowRect.width - (padding * 2)));
                options.Add(GUILayout.MaxHeight(windowRect.height - (padding * 2)));
            }
            else
            {
                options.Add(GUILayout.MaxWidth(windowRect.width - (padding)));
            }

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space(padding / 2f, true);
            current = EditorGUILayout.TextArea(current, style, options.ToArray());

            var lastRect = GUILayoutUtility.GetLastRect();
            bool isVerticalScrollbarVisible = lastRect.height > windowRect.height;

            if (!isVerticalScrollbarVisible)
            {
                EditorGUILayout.Space(padding / 2f, true);
            }

            EditorGUILayout.EndHorizontal();

            GUI.backgroundColor = Color.white;

            return current;
        }

        private static GUIStyle GetTextAreaStyle(Color backgroundColor)
        {
            var textColor = Color.white;

            if (QNoteSettings.Instance.SmartColor)
            {
                if (backgroundColor.r + backgroundColor.g + backgroundColor.b > 1.5f)
                {
                    textColor = Color.black;
                }

                if (QNoteSettings.Instance.InverseColor)
                {
                    Color.RGBToHSV(backgroundColor, H: out var h, S: out var s, out var v);
                    var negativeH = (h + 0.5f) % 1f;
                    textColor = Color.HSVToRGB(negativeH, s, v);
                }
            }

            var state = new GUIStyleState
            {
                textColor = textColor
            };
            var style = new GUIStyle(EditorStyles.textArea)
            {
                font = QNoteSettings.Instance.Font ?? EditorStyles.textArea.font,
                imagePosition = ImagePosition.ImageLeft,
                alignment = TextAnchor.UpperLeft,
                richText = QNoteSettings.Instance.RichText,
                wordWrap = QNoteSettings.Instance.WordWrap,
                clipping = TextClipping.Clip,
                stretchWidth = true,
                stretchHeight = true,
                fontSize = QNoteSettings.Instance.FontSize,
                fontStyle = FontStyle.Normal,
                normal = state,
                focused = state,
                active = state,
                hover = state,
            };
            return style;
        }
    }
}