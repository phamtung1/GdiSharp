using System;
using System.Drawing;
using GdiSharp.Components.Base;

namespace GdiSharp.Components
{
    public class GdiRectangle : GdiContainer
    {
        public float Width { get; set; }

        public float Height { get; set; }

        public int BorderWidth { get; set; } = 0;

        public Color BorderColor { get; set; } = Color.LightGray;

        protected override SizeF GetComponentSize(Graphics graphics)
        {
            return new SizeF(this.Width, this.Height);
        }

        public override void Render(Graphics graphics)
        {
            if (Width <= 0 || Height <= 0)
            {
                throw new ArgumentException("Invalid width/height!");
            }

            var position = GetAbsolutePosition(graphics);
            using (var brush = new SolidBrush(this.Color))
            {
                graphics.FillRectangle(brush, position.X, position.Y, this.Width, this.Height);
                if (BorderWidth > 0)
                {
                    using (var pen = new Pen(BorderColor, BorderWidth))
                    {
                        graphics.DrawRectangle(pen, position.X, position.Y, Width, Height);
                    }
                }
            }
        }
    }
}