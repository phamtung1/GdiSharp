using GdiSharp.Components.Base;
using System.Drawing;

namespace GdiSharp.Components
{
    public class GdiRectangle : GdiComponent
    {
        public override void Render(Graphics graphics)
        {
            var position = GetPosition(graphics);
            this.AbsolutePosition = new PointF(position.x, position.y);
            using (var brush = new SolidBrush(this.Color))
            {
                graphics.FillRectangle(brush, position.x, position.y, this.Width, this.Height);
            }
        }
    }
}