﻿using System;
using System.Drawing;

namespace GdiSharp.Components
{
    public class GdiGrid : GdiRectangle
    {
        public SizeF CellSize { get; set; }

        public Color LineColor { get; set; } = Color.LightGray;

        public int LineWidth { get; set; } = 1;

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
            graphics.DrawRectangle(pen, position.X, position.Y, Size.Width, Size.Height);
        }

        private void DrawRowLines(Graphics graphics, PointF position, Pen pen)
        {
            if (RowLinesVisible)
            {
                var numOfRows = (int)Math.Ceiling(Size.Height / CellSize.Height) + 1;
                for (int i = 0; i < numOfRows; i++)
                {
                    var y = position.Y + i * CellSize.Height;
                    graphics.DrawLine(pen, position.X, y, position.X + Size.Width, y);
                }
            }
        }

        private void DrawColumnLines(Graphics graphics, PointF position, Pen pen)
        {
            if (ColumnLinesVisible)
            {
                var numOfColumns = (int)Math.Ceiling(Size.Width / CellSize.Width);
                for (int i = 0; i < numOfColumns; i++)
                {
                    var x = position.X + i * CellSize.Width;
                    graphics.DrawLine(pen, x, position.Y, x, position.Y + Size.Height);
                }
            }
        }

        private void DrawColumnLinesRightToLeft(Graphics graphics, PointF position, Pen pen)
        {
            if (ColumnLinesVisible)
            {
                var startX = position.X + Size.Width;
                var numOfColumns = (int)Math.Ceiling(Size.Width / CellSize.Width);
                for (int i = 0; i < numOfColumns; i++)
                {
                    var x = startX - i * CellSize.Width;
                    graphics.DrawLine(pen, x, position.Y, x, position.Y + Size.Height);
                }
            }
        }
    }
}