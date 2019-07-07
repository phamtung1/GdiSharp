using System;
using System.Collections.Generic;
using System.Drawing;
using GdiSharp.Enum;

namespace GdiSharp.Components.Base
{
    public class GdiComponent : IGdiComponent
    {
        public Color Color { get; set; }

        internal PointF AbsolutePosition { get; set; }

        public HorizontalAlignment HorizontalAlignment { get; set; } = HorizontalAlignment.Left;

        public VerticalAlignment VerticalAlignment { get; set; } = VerticalAlignment.Top;

        public GdiComponent Parent { get; set; }

        public float MarginX { get; set; }

        public float MarginY { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        internal IList<GdiComponent> Children { get; set; }

        public void AddChild(GdiComponent component)
        {
            if (Children == null)
            {
                Children = new List<GdiComponent>();
            }

            component.Parent = this;
            Children.Add(component);
        }

        public virtual void Render(Graphics graphics)
        {
            throw new NotImplementedException();
        }

        protected virtual SizeF GetComponentSize(Graphics graphics)
        {
            return new SizeF(this.Width, this.Height);
        }

        protected (float x, float y) GetPosition(Graphics graphics)
        {
            if (this.Parent == null)
            {
                return (this.MarginX, this.MarginY);
            }

            float x;
            float y;
            var size = GetComponentSize(graphics);
            switch (this.HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    x = this.Parent.AbsolutePosition.X + this.MarginX;
                    break;

                case HorizontalAlignment.Center:
                    x = this.Parent.AbsolutePosition.X + (this.Parent.Width - size.Width) / 2;
                    break;

                default:
                    x = this.Parent.AbsolutePosition.X + this.Parent.Width - size.Width - this.MarginX;
                    break;
            }

            switch (this.VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    y = this.Parent.AbsolutePosition.Y + this.MarginY;
                    break;

                case VerticalAlignment.Middle:
                    y = this.Parent.AbsolutePosition.Y + (this.Parent.Height - size.Height) / 2;
                    break;

                default:
                    y = this.Parent.AbsolutePosition.Y + this.Parent.Height - size.Height - this.MarginY;
                    break;
            }

            return (x, y);
        }
    }
}