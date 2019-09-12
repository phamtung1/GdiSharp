using GdiSharp.Components.Base;
using System.Drawing;

namespace GdiSharp.Components
{
    public class GdiText : GdiContainer
    {
        public string Content { get; set; }

        public Font Font { get; set; }

        public override void Render(Graphics graphics)
        {
            using (var brush = new SolidBrush(this.Color))
            {
                var position = GetAbsolutePosition(graphics);
                graphics.DrawString(this.Content, this.Font, brush, position);
            }
        }

        protected override SizeF GetComponentSize(Graphics graphics)
        {
            return graphics.MeasureString(this.Content, this.Font);
        }
    }
}