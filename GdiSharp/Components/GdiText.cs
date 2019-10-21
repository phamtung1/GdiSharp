using GdiSharp.Components.Base;
using GdiSharp.Models;
using System;
using System.Drawing;

namespace GdiSharp.Components
{
    public class GdiText : GdiContainer
    {
        public string Content { get; set; }

        public SlimFont Font { get; set; }

        public StringAlignment TextAlign { get; set; } = StringAlignment.Near;

        public override void Render(Graphics graphics)
        {
            if (this.Font.Size == 0 || string.IsNullOrEmpty(this.Font.Name))
            {
                throw new ArgumentException("Invalid font");
            }

            if (this.BackgroundColor == Color.Empty)
            {
                this.BackgroundColor = Color.Black;
            }

            using (var brush = new SolidBrush(this.BackgroundColor))
            using (var font = this.Font.ToFatFont())
            using (StringFormat stringFormat = new StringFormat())
            {
                var position = GetAbsolutePosition(graphics);
                stringFormat.Alignment = TextAlign;
                if (TextAlign == StringAlignment.Far)
                {
                    var size = GetComponentSize(graphics);
                    position.X += size.Width;
                }
                else if (TextAlign == StringAlignment.Center)
                {
                    var size = GetComponentSize(graphics);
                    position.X += size.Width / 2;
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