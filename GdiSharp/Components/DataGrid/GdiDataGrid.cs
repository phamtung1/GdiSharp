using System;
using System.Collections.Generic;
using System.Drawing;

namespace GdiSharp.Components.DataGrid
{
    public class GdiDataGrid : GdiRectangle
    {
        public Color LineColor { get; set; } = Color.LightGray;

        public int LineWidth { get; set; } = 1;

        public int Rows { get; set; }

        public int Columns { get; set; }

        public IEnumerable<DataGridMergedCell> MergedCells { get; set; }

        public string[][] Texts { get; set; }

        public Color TextColor { get; set; } = Color.Black;

        public override void BeforeRendering(Graphics graphics)
        {
            if (Rows == 0 || Columns == 0)
            {
                throw new ArgumentException("Rows and Columns can not be zero");
            }

            base.BeforeRendering(graphics);

            var cellWidth = this.Size.Width / Columns;
            var cellHeight = this.Size.Height / Rows;
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    var size = new SizeF(cellWidth, cellHeight);
                    var margin = new PointF(col * cellWidth, row * cellHeight);

                    var mergedCell = GetMergedCell(row, col);
                    if (mergedCell != null)
                    {
                        size = new SizeF((mergedCell.ToCol - mergedCell.FromCol + 1) * cellWidth, (mergedCell.ToRow - mergedCell.FromRow + 1) * cellHeight);
                        margin = new PointF(mergedCell.FromCol * cellWidth, mergedCell.FromRow * cellHeight);
                    }
                    else if (IsInMergedPositions(row, col))
                    {
                        continue;
                    }

                    var cell = new GdiRectangle
                    {
                        Border = new Models.Border { Color = LineColor, Size = 1 },
                        Size = size,
                        Margin = margin
                    };
                    var text = new GdiText
                    {
                        Content = GetText(row,col),
                        TextColor = TextColor,
                        HorizontalAlignment = Enum.GdiHorizontalAlign.Center,
                        VerticalAlignment = Enum.GdiVerticalAlign.Middle,
                        TextAlign = StringAlignment.Center
                    };

                    cell.AddChild(text);
                    this.AddChild(cell);
                }
            }
        }

        private string GetText(int row, int col)
        {
            if (Texts == null || Texts.Length <= row)
            {
                return string.Empty;
            }

            var rowData = Texts[row];
            if (rowData.Length <= col)
            {
                return string.Empty;
            }

            return rowData[col];
        }

        private DataGridMergedCell GetMergedCell(int row, int col)
        {
            if(MergedCells == null)
            {
                return null;
            }

            foreach (var item in MergedCells)
            {
                if (item.FromRow == row && item.FromCol == col)
                {
                    return item;
                }
            }

            return null;
        }

        private bool IsInMergedPositions(int row, int col)
        {
            if (MergedCells == null)
            {
                return false;
            }

            foreach (var item in MergedCells)
            {
                if (item.FromRow <= row && item.ToRow >= row && item.FromCol <= col && item.ToCol >= col)
                {
                    return true;
                }
            }

            return false;
        }
    }
}