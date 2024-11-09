namespace QuickNotes
{
    public static class QNoteColorExtensions
    {
        public static UnityEngine.Color ToColor(this QNoteColor color)
        {
            return new UnityEngine.Color(color.r, color.g, color.b, 1f);
        }
        public static QNoteColor ToQNoteColor(this UnityEngine.Color color)
        {
            return new QNoteColor
            {
                r = color.r,
                g = color.g,
                b = color.b
            };
        }
    }
}