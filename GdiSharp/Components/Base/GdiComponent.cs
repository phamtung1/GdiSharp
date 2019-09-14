using System;
using System.Drawing;
using GdiSharp.Enum;

namespace GdiSharp.Components.Base
{
    public abstract class GdiComponent : IGdiComponent
    {
        public GdiHorizontalAlign HorizontalAlignment { get; set; } = GdiHorizontalAlign.Left;

        public GdiVerticalAlign VerticalAlignment { get; set; } = GdiVerticalAlign.Top;

        public Color Color { get; set; }

        public GdiComponent Parent { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public virtual void BeforeRendering()
        {
        }

        public virtual void Render(Graphics graphics)
        {
            throw new NotImplementedException();
        }

        protected virtual SizeF GetComponentSize(Graphics graphics)
        {
            return new SizeF(0, 0);
        }

        protected virtual PointF GetAbsolutePosition(Graphics graphics)
        {
            if (this.Parent == null)
            {
                return new PointF(this.X, this.Y);
            }

            var parentAbsolutePosition = this.Parent.GetAbsolutePosition(graphics);
            float absoluteX;
            float absoluteY;
            var size = GetComponentSize(graphics);
            var parentSize = this.Parent.GetComponentSize(graphics);

            switch (this.HorizontalAlignment)
            {
                case GdiHorizontalAlign.Left:
                    absoluteX = parentAbsolutePosition.X + this.X;
                    break;

                case GdiHorizontalAlign.Center:
                    absoluteX = parentAbsolutePosition.X + (parentSize.Width - size.Width) / 2;
                    break;

                default:
                    absoluteX = parentAbsolutePosition.X + parentSize.Width - size.Width - this.X;
                    break;
            }

            switch (this.VerticalAlignment)
            {
                case GdiVerticalAlign.Top:
                    absoluteY = parentAbsolutePosition.Y + this.Y;
                    break;

                case GdiVerticalAlign.Middle:
                    absoluteY = parentAbsolutePosition.Y + (parentSize.Height - size.Height) / 2;
                    break;

                default:
                    absoluteY = parentAbsolutePosition.Y + parentSize.Height - size.Height - this.Y;
                    break;
            }

            return new PointF(absoluteX, absoluteY);
        }
    }
}