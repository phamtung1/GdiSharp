using GdiSharp.Components.Base;
using GdiSharp.Enum;
using System.Drawing;

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
                graphics.DrawString(this.Content, this.Font, brush, x , y);
            }
        }

        private (float x, float y) GetPosition(Graphics graphics)
        {
            if (this.Parent == null)
            {
                return (this.X, this.Y);
            }

            float x = 0;
            float y = 0;
            //var point = new PointF(this.Parent.AbsolutePosition.X + this.X, this.Parent.AbsolutePosition.Y + this.Y);
            var size = graphics.MeasureString(this.Content, this.Font);
            switch (this.HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    x = this.Parent.AbsolutePosition.X + this.X;
                    break;

                case HorizontalAlignment.Center:
                    x = this.Parent.AbsolutePosition.X + (this.Parent.Width - size.Width) / 2;
                    break;

                default:
                    x = this.Parent.AbsolutePosition.X + this.Parent.Width - size.Width - this.X;
                    break;
            }

            switch (this.VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    y = this.Parent.AbsolutePosition.Y + this.Y;
                    break;

                case VerticalAlignment.Middle:
                    y = this.Parent.AbsolutePosition.Y + (this.Parent.Height - size.Height) / 2;
                    break;

                default:
                    y = this.Parent.AbsolutePosition.Y + this.Parent.Height - size.Height - this.Y;
                    break;
            }


            return (x, y);
        }
    }
}