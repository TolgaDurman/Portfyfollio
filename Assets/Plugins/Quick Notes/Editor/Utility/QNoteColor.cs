using System;

namespace QuickNotes
{
    [Serializable]
    public struct QNoteColor
    {
        public float r;
        public float g;
        public float b;
        public static QNoteColor Default => new QNoteColor
        {
            r = 0.2f,
            g = 0.2f,
            b = 0.2f
        };
    }
}