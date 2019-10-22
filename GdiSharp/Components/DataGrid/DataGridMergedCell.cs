using System;
using System.Collections.Generic;
using System.Text;

namespace GdiSharp.Components.DataGrid
{
    public class DataGridMergedCell
    {
        public int FromRow { get; set; }

        public int FromCol { get; set; }

        public int ToRow { get; set; }

        public int ToCol { get; set; }

        public DataGridMergedCell(int fromRow, int fromCol, int toRow, int toCol)
        {
            FromRow = fromRow;
            FromCol = fromCol;
            ToRow = toRow;
            ToCol = toCol;
        }
    }
}
