using System;
using System.IO;
using UnityEngine;
#if NEWTONSOFT_JSON_NUGET
using Newtonsoft.Json;
#endif

namespace QuickNotes
{
    internal static class SaveUtility
    {
        private static string _memosPath;

        public static string MemosPath
        {
            get
            {
                if (!string.IsNullOrEmpty(_memosPath)) return _memosPath;

                _memosPath = Path.Combine(Application.dataPath, "Memos~");
                if (!Directory.Exists(_memosPath))
                {
                    Directory.CreateDirectory(_memosPath);
                }

                return _memosPath;
            }
        }

        public static bool Exists(string name)
        {
            var path = Path.Combine(MemosPath, name + ".qnote");
            return File.Exists(path);
        }

        public static NoteData LoadMemo(string name)
        {
            var path = Path.Combine(MemosPath, name + ".qnote");
            if (!File.Exists(path))
            {
                return new NoteData
                {
                    NoteText = String.Empty,
                    SelectedColor = QNoteSettings.Instance.StartColor.ToQNoteColor()
                };
            }

            var json = File.ReadAllText(path);
#if NEWTONSOFT_JSON_NUGET
            return JsonConvert.DeserializeObject<NoteData>(json);
#else
            return JsonUtility.FromJson<NoteData>(json);
#endif
        }

        public static void SaveMemo(string name, NoteData noteData)
        {
            if (Directory.Exists(MemosPath) == false)
            {
                Directory.CreateDirectory(MemosPath);
            }

            var path = Path.Combine(MemosPath, name + ".qnote");
#if NEWTONSOFT_JSON_NUGET
            var json = JsonConvert.SerializeObject(noteData);
#else
            var json = JsonUtility.ToJson(noteData);
#endif
            var file = File.CreateText(path);
            file.Write(json);
            file.Close();
        }

        public static void DeleteMemo(string name)
        {
            var path = Path.Combine(MemosPath, name + ".qnote");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}