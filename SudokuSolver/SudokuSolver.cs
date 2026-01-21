using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    namespace SudokuSolver
    {
        internal class SudokuSolver
        {
            private bool IsSafe(SudokuBoard board, int row, int col, int num)
            {
                // TODO
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
                    board.SetCell(row, col, num);

                    if (Solve(board))
                        return true;

                    board.SetCell(row, col, 0); // Backtrack
                }


                return false;
            }
        }
    }
}

