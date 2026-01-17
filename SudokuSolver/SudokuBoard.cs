using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    internal class SudokuBoard
    {
        public const int ROWS = 9;
        public const int COLUMNS = 9;

        int[,] Grid = new int[ROWS, COLUMNS];

        public int GetCell(int x, int y)
        {
            return Grid[x, y];
        }
        public void SetCell(int x, int y, int value)
        {
            Grid[x, y] = value;
        }

        public bool IsEmpty(int x, int y)
        {
            if (Grid[x, y] == 0)
                return true;
            return false;
        }
    }
}
