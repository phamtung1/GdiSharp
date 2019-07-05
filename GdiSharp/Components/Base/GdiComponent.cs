using GdiSharp.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GdiSharp.Components.Base
{
    public class GdiComponent : IGdiComponent
    {
        public Color Color { get; set; }

        internal PointF AbsolutePosition { get; set; }

        public HorizontalAlignment HorizontalAlignment { get; set; } = HorizontalAlignment.Left;

        public VerticalAlignment VerticalAlignment { get; set; } = VerticalAlignment.Top;

        public GdiComponent Parent { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

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
    }
}