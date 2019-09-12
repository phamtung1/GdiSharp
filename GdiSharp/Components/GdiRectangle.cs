using GdiSharp.Components.Base;
using System.Drawing;

namespace GdiSharp.Components
{
    public class GdiRectangle : GdiContainer
    {
        public override void Render(Graphics graphics)
        {
            var position = GetAbsolutePosition(graphics);
            using (var brush = new SolidBrush(this.Color))
            {
                graphics.FillRectangle(brush, position.X, position.Y, this.Width, this.Height);
            }
        }
    }
}