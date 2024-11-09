using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace QuickNotes
{
    internal static class ColorPicker
    {
        private const string __internalColorEditorTypeName = "UnityEditor.ColorPicker, UnityEditor";
        private static EditorWindow _internalColorEditor;

        public static void OpenColorPicker(Action<Color> OnColorChanged, Color selectedColor)
        {
            try
            {
                Type colorPicker = Type.GetType(__internalColorEditorTypeName);
                _internalColorEditor = ScriptableObject.CreateInstance(colorPicker) as EditorWindow;

                if (_internalColorEditor == null)
                {
                    Debug.LogError("Could not create ColorPicker instance");
                    return;
                }

                var colorPickerType = _internalColorEditor.GetType();

                var method = colorPickerType.GetMethod("Show", BindingFlags.Static | BindingFlags.Public, null,
                    new Type[] { typeof(Action<Color>), typeof(Color), typeof(bool), typeof(bool) },
                    null);

                if (method == null)
                {
                    Debug.LogError("Could not find Show method in ColorPicker");
                    return;
                }

                try
                {
                    method?.Invoke(_internalColorEditor,
                        new object[] { new Action<Color>(OnColorChanged), selectedColor, false, false });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Could not open ColorPicker: " + e.Message);
            }
        }
    }
}