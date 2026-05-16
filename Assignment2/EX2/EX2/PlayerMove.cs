using System;
using System.Collections.Generic;
using System.Text;

namespace EX2
{
    public struct PlayerMove
    {
        public int Row;
        public int Column;
        public PlayerMove(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int GetRow()
        {
            return Row;
        }
        public int GetColumn()
        { 
            return Column;
        }
    }
}
