using System.Drawing;

namespace GdiSharp.Models
{
    public struct SlimFont
    {
        public static readonly SlimFont Default = new SlimFont("Arial", 12, FontStyle.Regular);

        public string Name { get; set; }

        public float Size { get; set; }

        public FontStyle Style { get; set; }

        public SlimFont(string name, float size, FontStyle style = FontStyle.Regular)
        {
            this.Name = name;
            this.Size = size;
            this.Style = style;
        }

        public Font ToFatFont()
        {
            return new Font(Name, Size, Style);
        }

        public static SlimFont FromFatFont(Font font)
        {
            return new SlimFont(font.Name, font.Size, font.Style);
        }
    }
}