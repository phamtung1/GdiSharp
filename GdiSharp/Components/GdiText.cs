using GdiSharp.Components.Base;
using GdiSharp.Models;
using System;
using System.Drawing;

namespace GdiSharp.Components
{
    public class GdiText : GdiContainer
    {
        public string Content { get; set; }

        public SlimFont Font { get; set; } = SlimFont.DefaultSmall;

        public StringAlignment TextAlign { get; set; } = StringAlignment.Near;

        public Color TextColor { get; set; } = Color.Black;

        public override void Render(Graphics graphics)
        {
            if (this.Font.Size == 0 || string.IsNullOrEmpty(this.Font.Name))
            {
                throw new ArgumentException("Invalid font");
            }

            using (var brush = new SolidBrush(this.TextColor))
            using (var font = this.Font.ToFatFont())
            using (StringFormat stringFormat = new StringFormat())
            {
                var position = GetAbsolutePosition(graphics);
                stringFormat.Alignment = TextAlign;
                var size = GetComponentSize(graphics);
                if (TextAlign == StringAlignment.Far)
                {
                    position.X += size.Width;
                }
                else if (TextAlign == StringAlignment.Center)
                {
                    position.X += size.Width / 2;
                }

                if (BackgroundColor != Color.Empty)
                {
                    using (var backgroundBrush = new SolidBrush(this.BackgroundColor))
                    {
                        graphics.FillRectangle(backgroundBrush, position.X, position.Y, size.Width, size.Height);
                    }
                }

                graphics.DrawString(this.Content, font, brush, position, stringFormat);
            }
        }

        protected override SizeF GetComponentSize(Graphics graphics)
        {
            using (var font = this.Font.ToFatFont())
            {
                return graphics.MeasureString(this.Content, font);
            }
        }
    }
}