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
                var position = GetPosition(graphics);
                graphics.DrawString(this.Content, this.Font, brush, position);
            }
        }

        private PointF GetPosition(Graphics graphics)
        {
            if (this.Parent == null)
            {
                return new PointF(this.X, this.Y);
            }

            var point = new PointF(this.Parent.AbsolutePosition.X + this.X, this.Parent.AbsolutePosition.Y + this.Y);
            var size = graphics.MeasureString(this.Content, this.Font);
            
            switch (this.ContentAlignment)
            {
                case ContentAlignment.MiddleLeft:
                    point.Y = this.Parent.AbsolutePosition.Y + (this.Parent.Height - size.Height) / 2;
                    break;

                case ContentAlignment.MiddleCenter:
                    point.X = this.Parent.AbsolutePosition.X + (this.Parent.Width - size.Width) / 2;
                    point.Y = this.Parent.AbsolutePosition.Y + (this.Parent.Height - size.Height) / 2;
                    break;

                case ContentAlignment.MiddleRight:
                    point.X = this.Parent.AbsolutePosition.X + this.Parent.Width - size.Width - this.X;
                    point.Y = this.Parent.AbsolutePosition.Y + (this.Parent.Height - size.Height) / 2;
                    break;

                case ContentAlignment.BottomLeft:
                    point.Y = this.Parent.AbsolutePosition.Y + this.Parent.Height - size.Height - this.Y;
                    break;
                case ContentAlignment.BottomCenter:
                    point.X = this.Parent.AbsolutePosition.X + (this.Parent.Width - size.Width) / 2;
                    point.Y = this.Parent.AbsolutePosition.Y + this.Parent.Height - size.Height - this.Y;
                    break;

                case ContentAlignment.BottomRight:
                    point.X = this.Parent.AbsolutePosition.X + this.Parent.Width - size.Width - this.X;
                    point.Y = this.Parent.AbsolutePosition.Y + this.Parent.Height - size.Height - this.Y;
                    break;

                //case DockStyle.Center:
                //    point.X = this.Parent.AbsolutePosition.X + (this.Parent.Width - size.Width) / 2;
                //    point.Y = this.Parent.AbsolutePosition.Y + (this.Parent.Height - size.Height) / 2;
                //    break;



                default:
                    break;
            }

            return point;
        }
    }
}