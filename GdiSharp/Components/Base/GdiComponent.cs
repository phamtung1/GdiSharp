using GdiSharp.Enum;
using System;
using System.Drawing;

namespace GdiSharp.Components.Base
{
    public abstract class GdiComponent : IGdiComponent
    {
        public HorizontalAlignment HorizontalAlignment { get; set; } = HorizontalAlignment.Left;

        public VerticalAlignment VerticalAlignment { get; set; } = VerticalAlignment.Top;

        public Color Color { get; set; }

        public GdiContainer Parent { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

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
            switch (this.HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    absoluteX = parentAbsolutePosition.X + this.X;
                    break;

                case HorizontalAlignment.Center:
                    absoluteX = parentAbsolutePosition.X + (this.Parent.Width - size.Width) / 2;
                    break;

                default:
                    absoluteX = parentAbsolutePosition.X + this.Parent.Width - size.Width - this.X;
                    break;
            }

            switch (this.VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    absoluteY = parentAbsolutePosition.Y + this.Y;
                    break;

                case VerticalAlignment.Middle:
                    absoluteY = parentAbsolutePosition.Y + (this.Parent.Height - size.Height) / 2;
                    break;

                default:
                    absoluteY = parentAbsolutePosition.Y + this.Parent.Height - size.Height - this.Y;
                    break;
            }

            return new PointF(absoluteX, absoluteY);
        }
    }
}