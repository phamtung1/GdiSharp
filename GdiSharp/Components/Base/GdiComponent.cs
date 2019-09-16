using GdiSharp.Enum;
using System.Drawing;

namespace GdiSharp.Components.Base
{
    public abstract class GdiComponent : IGdiComponent
    {
        public GdiHorizontalAlign HorizontalAlignment { get; set; } = GdiHorizontalAlign.Left;

        public GdiVerticalAlign VerticalAlignment { get; set; } = GdiVerticalAlign.Top;

        public Color Color { get; set; }

        public GdiComponent Parent { get; set; }

        public PointF Margin { get; set; } = new PointF();

        public virtual void BeforeRendering()
        {
        }

        public virtual void Render(Graphics graphics)
        {
        }

        protected virtual SizeF GetComponentSize(Graphics graphics)
        {
            return new SizeF(0, 0);
        }

        protected virtual Brush GetFillBrush(Graphics graphics)
        {
            return new SolidBrush(Color);
        }

        protected virtual PointF GetAbsolutePosition(Graphics graphics)
        {
            if (this.Parent == null)
            {
                return Margin;
            }

            var parentAbsolutePosition = this.Parent.GetAbsolutePosition(graphics);
            float absoluteX;
            float absoluteY;
            var size = GetComponentSize(graphics);
            var parentSize = this.Parent.GetComponentSize(graphics);

            switch (this.HorizontalAlignment)
            {
                case GdiHorizontalAlign.Left:
                    absoluteX = parentAbsolutePosition.X + this.Margin.X;
                    break;

                case GdiHorizontalAlign.Center:
                    absoluteX = parentAbsolutePosition.X + (parentSize.Width - size.Width) / 2;
                    break;

                default:
                    absoluteX = parentAbsolutePosition.X + parentSize.Width - size.Width - this.Margin.X;
                    break;
            }

            switch (this.VerticalAlignment)
            {
                case GdiVerticalAlign.Top:
                    absoluteY = parentAbsolutePosition.Y + this.Margin.Y;
                    break;

                case GdiVerticalAlign.Middle:
                    absoluteY = parentAbsolutePosition.Y + (parentSize.Height - size.Height) / 2;
                    break;

                default:
                    absoluteY = parentAbsolutePosition.Y + parentSize.Height - size.Height - this.Margin.Y;
                    break;
            }

            return new PointF(absoluteX, absoluteY);
        }
    }
}