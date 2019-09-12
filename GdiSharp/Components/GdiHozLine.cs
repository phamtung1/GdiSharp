using GdiSharp.Components.Base;
using System.Drawing;

namespace GdiSharp.Components
{
    public class GdiHozLine : GdiComponent
    {
        public int LineHeight { get; set; } = 1;

        public float Length { get; set; }

        protected override SizeF GetComponentSize(Graphics graphics)
        {
            return new SizeF(this.Length, 1);
        }

        public override void Render(Graphics graphics)
        {
            var position = GetAbsolutePosition(graphics);
            using (var pen = new Pen(this.Color, LineHeight))
            {
                graphics.DrawLine(pen, position.X, position.Y, position.X + this.Length, position.Y);
            }
        }
    }
}