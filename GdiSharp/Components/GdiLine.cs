using GdiSharp.Components.Base;
using System.Drawing;

namespace GdiSharp.Components
{
    public class GdiLine : GdiComponent
    {
        public int LineHeight { get; set; } = 1;

        public float X2 { get; set; }

        public float Y2 { get; set; }

        public override void Render(Graphics graphics)
        {
            var position = GetAbsolutePosition(graphics);
            using (var pen = new Pen(this.Color, LineHeight))
            {
                graphics.DrawLine(pen, position.X, position.Y, this.X2, this.Y2);
            }
        }
    }
}