using System;
using System.Drawing;
using GdiSharp.Components.Base;
using GdiSharp.Models;

namespace GdiSharp.Components
{
    public class GdiRectangle : GdiContainer
    {
        public SizeF Size { get; set; }

        public Border Border { get; set; } = Border.Empty;

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
                if (Border.Size > 0)
                {
                    using (var pen = new Pen(Border.Color, Border.Size))
                    {
                        graphics.DrawRectangle(pen, position.X, position.Y, Size.Width, Size.Height);
                    }
                }
            }
        }
    }
}