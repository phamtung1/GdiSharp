using System.Drawing;
using GdiSharp.Components.Base;

namespace GdiSharp.Components
{
    public class GdiText : GdiComponent
    {
        public string Content { get; set; }

        //public bool IsDockOutside { get; set; } = false;

        //public TextAlignment Alignment { get; set; } = TextAlignment.Left;

        public Font Font { get; set; }

        public override void Render(Graphics graphics)
        {
            using (var brush = new SolidBrush(this.Color))
            {
                (float x, float y) = GetPosition(graphics);
                graphics.DrawString(this.Content, this.Font, brush, x, y);
            }
        }

        protected override SizeF GetComponentSize(Graphics graphics)
        {
            return graphics.MeasureString(this.Content, this.Font);
        }
    }
}