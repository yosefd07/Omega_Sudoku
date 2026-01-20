using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    internal class SudokuValidator
    {
        public bool RowCheck(SudokuBoard board)
        {

            for (int row = 0; row < 9; row++)
            {
                bool[] seen = new bool[10];

                for (int col = 0; col < 9; col++)
                {
                    int value = board.GetCell(row, col);
                    if (value == 0)
                        continue;

                    if (seen[value])
                        return false;

                    seen[value] = true;
                }
            }
            return true;
        }
            public bool ColumnCheck(SudokuBoard board)
        {

            for (int col = 0; col < 9; col++)
            {
                bool[] seen = new bool[10];

                for (int row = 0; row < 9; row++)
                {
                    int value = board.GetCell(row, col);
                    if (value == 0)
                        continue;

                    if (seen[value])
                        return false;

                    seen[value] = true;
                }
            }
            return true;
        }
        public bool BoxCheck(SudokuBoard board)
        {
            for (int boxCol = 0; boxCol < 3; boxCol++)
            {

                for (int boxRow = 0; boxRow < 3; boxRow++)
                {
                    int startRow = boxRow * 3;
                    int startCol = boxCol * 3;

                    bool[] seen = new bool[10];
                    for (int col = startCol; startCol + col < 3; col++)
                    {

                        for (int row = startRow; startRow +  row < 3; row++)
                        {
                            int value = board.GetCell(row, col);
                            if (value == 0)
                                continue;

                            if (seen[value])
                                return false;

                        }
                    }
                }
            }
            return true;
        }
        public bool IsValid(SudokuBoard board)
        {
            return RowCheck(board)
                && ColumnCheck(board)
                && BoxCheck(board);
        }

    }
}
