using GdiSharp.Components.Base;
using System.Drawing;

namespace GdiSharp.Components
{
    public class GdiRectangle : GdiComponent
    {
        public override void Render(Graphics graphics)
        {
            var position = GetPosition();
            using (var brush = new SolidBrush(this.Color))
            {
                graphics.FillRectangle(brush, position.X, position.Y, this.Width, this.Height);
            }
        }

        private PointF GetPosition()
        {
            var position = this.Parent == null ?
                    new PointF(this.X, this.Y) :
                    new PointF(this.Parent.AbsolutePosition.X + this.X, this.Parent.AbsolutePosition.Y + this.Y);

            this.AbsolutePosition = position;
            return position;
        }
    }
}