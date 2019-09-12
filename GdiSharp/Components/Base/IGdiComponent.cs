using System.Drawing;
using GdiSharp.Enum;

namespace GdiSharp.Components.Base
{
    public interface IGdiComponent
    {
        Color Color { get; set; }
        HorizontalAlignment HorizontalAlignment { get; set; }
        VerticalAlignment VerticalAlignment { get; set; }
        float X { get; set; }
        float Y { get; set; }

        void Render(Graphics graphics);
    }
}