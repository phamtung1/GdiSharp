using System.Drawing;

namespace GdiSharp.Models
{
    public struct Border
    {
        public static Border Empty
        {
            get { return new Border(0); }
        }

        public Color Color { get; set; }

        public int Size { get; set; }

        public Border(int size)
        {
            Color = Color.LightGray;
            Size = size;
        }

        public Border(int size, Color color)
        {
            Color = color;
            Size = size;
        }
    }
}