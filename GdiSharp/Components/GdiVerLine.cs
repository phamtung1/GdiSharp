using GdiSharp.Components.Base;
using System.Drawing;

namespace GdiSharp.Components
{
    public class GdiVerLine : GdiComponent
    {
        public int LineHeight { get; set; } = 1;

        public float Length { get; set; }

        public override void Render(Graphics graphics)
        {
            var position = GetAbsolutePosition(graphics);
            using (var pen = new Pen(this.Color, LineHeight))
            {
                graphics.DrawLine(pen, position.X, position.Y, position.X, position.Y + this.Length);
            }
        }
    }
}