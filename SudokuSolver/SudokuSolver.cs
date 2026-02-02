using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    internal class SudokuSolver
    {
        private bool IsSafe(SudokuBoard board, int row, int col, int num)
        {
            for (int c = 0; c < 9; c++)
            {
                if (board.GetCell(row, c) == num)
                    return false;
            }

            for (int r = 0; r < 9; r++)
            {
                if (board.GetCell(r, col) == num)
                    return false;
            }

            int startRow = (row / 3) * 3;
            int startCol = (col / 3) * 3;

            for (int r = startRow; r < startRow + 3; r++)
            {
                for (int c = startCol; c < startCol + 3; c++)
                {
                    if (board.GetCell(r, c) == num)
                        return false;
                }
            }

            return true;
        }

        private bool FindEmptyCell(SudokuBoard board, out int row, out int col)
        {
            for (row = 0; row < 9; row++)
            {
                for (col = 0; col < 9; col++)
                {
                    if (board.IsEmpty(row, col))
                        return true;
                }
            }

            row = -1;
            col = -1;
            return false;
        }
        public bool Solve(SudokuBoard board)
        {
            int row, col;

            if (!FindEmptyCell(board, out row, out col))
                return true;

            for (int num = 1; num <= 9; num++)
            {
                if (IsSafe(board, row, col, num))
                {
                    board.SetCell(row, col, num);

                    if (Solve(board))
                        return true;

                    board.SetCell(row, col, 0);
                }
            }

            return false;
        }
    }
}

