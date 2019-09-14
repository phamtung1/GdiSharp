using System;
using System.Drawing;
using GdiSharp.Components.Base;

namespace GdiSharp.Components
{
    public class GdiRectangle : GdiContainer
    {
        public SizeF Size { get; set; }

        public int BorderWidth { get; set; } = 0;

        public Color BorderColor { get; set; } = Color.LightGray;

        protected override SizeF GetComponentSize(Graphics graphics)
        {
            return this.Size;
        }

        public override void Render(Graphics graphics)
        {
            if (Size == null || Size.Width <= 0 || Size.Height <= 0)
            {
                throw new ArgumentException("Invalid width/height!");
            }

            var position = GetAbsolutePosition(graphics);
            using (var brush = new SolidBrush(this.Color))
            {
                graphics.FillRectangle(brush, position.X, position.Y, this.Size.Width, this.Size.Height);
                if (BorderWidth > 0)
                {
                    using (var pen = new Pen(BorderColor, BorderWidth))
                    {
                        graphics.DrawRectangle(pen, position.X, position.Y, Size.Width, Size.Height);
                    }
                }
            }
        }
    }
}