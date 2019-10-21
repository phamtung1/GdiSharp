using System.Drawing;
using GdiSharp.Enum;

namespace GdiSharp.Components.Base
{
    public interface IGdiComponent
    {
        Color BackgroundColor { get; set; }

        GdiHorizontalAlign HorizontalAlignment { get; set; }

        GdiVerticalAlign VerticalAlignment { get; set; }

        PointF Margin { get; set; }

        void Render(Graphics graphics);
    }
}