using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    internal class SudokuSolver
    {
        private bool[,] rows = new bool[9, 10];
        private bool[,] cols = new bool[9, 10];
        private bool[,] boxes = new bool[9, 10];
        private void InitializeCache(SudokuBoard board)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    int value = board.GetCell(row, col);
                    if (value != 0)
                    {
                        rows[row, value] = true;
                        cols[col, value] = true;

                        int box = (row / 3) * 3 + col / 3;
                        boxes[box, value] = true;
                    }
                }
            }
        }

        private bool IsSafe(int row, int col, int num)
        {
            int box = (row / 3) * 3 + col / 3;
            return !rows[row, num]
                && !cols[col, num]
                && !boxes[box, num];
        }


        private bool FindBestEmptyCell(SudokuBoard board, out int bestRow, out int bestCol)
        {
            bestRow = -1;
            bestCol = -1;
            int bestCount = 10;

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (!board.IsEmpty(row, col))
                        continue;

                    int count = 0;
                    for (int num = 1; num <= 9; num++)
                    {
                        if (IsSafe( row, col, num))
                            count++;
                    }

                    if (count < bestCount)
                    {
                        bestCount = count;
                        bestRow = row;
                        bestCol = col;

                        if (count == 1)
                            return true;
                    }
                }
            }

            return bestRow != -1;
        }

        public bool Solve(SudokuBoard board)
        {
            InitializeCache(board);
            return SolveInternal(board);
        }

        private bool SolveInternal(SudokuBoard board)

        {
            int row, col;

            if (!FindBestEmptyCell(board, out row, out col))
                return true;


            for (int num = 1; num <= 9; num++)
            {
                if (IsSafe( row, col, num))
                {
                    board.SetCell(row, col, num);
                    rows[row, num] = true;
                    cols[col, num] = true;
                    boxes[(row / 3) * 3 + col / 3, num] = true;


                    if (SolveInternal(board))
                        return true;


                    board.SetCell(row, col, 0);
                    rows[row, num] = false;
                    cols[col, num] = false;
                    boxes[(row / 3) * 3 + col / 3, num] = false;

                }
            }

            return false;
        }
    }
}

