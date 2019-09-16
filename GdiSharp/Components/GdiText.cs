using GdiSharp.Components.Base;
using GdiSharp.Models;
using System.Drawing;

namespace GdiSharp.Components
{
    public class GdiText : GdiContainer
    {
        public string Content { get; set; }

        public SlimFont Font { get; set; }

        public bool IsTextAlignRight { get; set; }

        public override void Render(Graphics graphics)
        {
            using (var brush = new SolidBrush(this.Color))
            using (var font = this.Font.ToFatFont())
            using (StringFormat stringFormat = new StringFormat())
            {
                var position = GetAbsolutePosition(graphics);

                if (this.IsTextAlignRight)
                {
                    var size = GetComponentSize(graphics);
                    stringFormat.Alignment = StringAlignment.Far;
                    position.X += size.Width;
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