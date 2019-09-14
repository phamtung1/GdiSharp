using System.Drawing;
using GdiSharp.Enum;

namespace GdiSharp.Components.Base
{
    public interface IGdiComponent
    {
        Color Color { get; set; }
        GdiHorizontalAlign HorizontalAlignment { get; set; }
        GdiVerticalAlign VerticalAlignment { get; set; }
        float MarginLeft { get; set; }
        float MarginTop { get; set; }

        void Render(Graphics graphics);
    }
}