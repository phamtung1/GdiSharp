using System.Drawing;
using GdiSharp.Enum;

namespace GdiSharp.Components.Base
{
    public interface IGdiComponent
    {
        Color Color { get; set; }
        GdiHorizontalAlign HorizontalAlignment { get; set; }
        GdiVerticalAlign VerticalAlignment { get; set; }
        float X { get; set; }
        float Y { get; set; }

        void Render(Graphics graphics);
    }
}