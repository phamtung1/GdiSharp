using GdiSharp.Components.Base;
using System;
using System.Drawing;

namespace GdiSharp.Components
{
    public class GdiGrid : GdiRectangle
    {
        public float CellWidth { get; set; }

        public float CellHeight { get; set; }

        public Color LineColor { get; set; } = Color.LightGray;

        public int LineWidth { get; set; } = 1;

        public bool GridBorderVisible { get; set; }

        public bool RowLinesVisible { get; set; } = true;

        public bool ColumnLinesVisible { get; set; } = true;

        public bool IsDrawnFromRightToLeft { get; set; }

        public override void Render(Graphics graphics)
        {
            var position = GetAbsolutePosition(graphics);
            using (var pen = new Pen(this.LineColor, LineWidth))
            {
                DrawGridBorder(graphics, position, pen);
                DrawRowLines(graphics, position, pen);
                if (IsDrawnFromRightToLeft)
                {
                    DrawColumnLinesRightToLeft(graphics, position, pen);
                }
                else
                {
                    DrawColumnLines(graphics, position, pen);
                }
            }
        }

        private void DrawGridBorder(Graphics graphics, PointF position, Pen pen)
        {
            if (GridBorderVisible)
            {
                graphics.DrawRectangle(pen, position.X, position.Y, Width, Height);
            }
        }

        private void DrawRowLines(Graphics graphics, PointF position, Pen pen)
        {
            if (RowLinesVisible)
            {
                var numOfRows = (int)Math.Ceiling(Height / CellHeight);
                for (int i = 0; i < numOfRows; i++)
                {
                    var y = position.Y + i * CellHeight;
                    graphics.DrawLine(pen, position.X, y, position.X + Width, y);
                }
            }
        }

        private void DrawColumnLines(Graphics graphics, PointF position, Pen pen)
        {
            if (ColumnLinesVisible)
            {
                var numOfColumns = (int)Math.Ceiling(Width / CellWidth);
                for (int i = 0; i < numOfColumns; i++)
                {
                    var x = position.X + i * CellWidth;
                    graphics.DrawLine(pen, x, position.Y, x, position.Y + Height);
                }
            }
        }

        private void DrawColumnLinesRightToLeft(Graphics graphics, PointF position, Pen pen)
        {
            if (ColumnLinesVisible)
            {
                var startX = position.X + Width;
                var numOfColumns = (int)Math.Ceiling(Width / CellWidth);
                for (int i = 0; i < numOfColumns; i++)
                {
                    var x = startX - i * CellWidth;
                    graphics.DrawLine(pen, x, position.Y, x, position.Y + Height);
                }
            }
        }
    }
}