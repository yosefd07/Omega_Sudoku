using System;
using System.Collections.Generic;

namespace SudokuSolver
{
    internal class SudokuSolver
    {
        private bool[,] _rows = new bool[9, 10];
        private bool[,] _cols = new bool[9, 10];
        private bool[,] _boxes = new bool[9, 10];
        private int[,] _board = new int[9, 9];

        public bool Solve(SudokuBoard boardInput)
        {

            Initialize(boardInput);

            if (SolveRecursive())
            {

                for (int r = 0; r < 9; r++)
                    for (int c = 0; c < 9; c++)
                        boardInput.SetCell(r, c, _board[r, c]);
                return true;
            }

            return false;
        }

        private void Initialize(SudokuBoard boardInput)
        {
            Array.Clear(_rows, 0, _rows.Length);
            Array.Clear(_cols, 0, _cols.Length);
            Array.Clear(_boxes, 0, _boxes.Length);

            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    int val = boardInput.GetCell(r, c);
                    _board[r, c] = val;
                    if (val != 0)
                    {
                        Mark(r, c, val, true);
                    }
                }
            }
        }

        private void Mark(int r, int c, int val, bool state)
        {
            int boxIdx = (r / 3) * 3 + (c / 3);
            _rows[r, val] = state;
            _cols[c, val] = state;
            _boxes[boxIdx, val] = state;
        }

        private bool IsSafe(int r, int c, int val)
        {
            int boxIdx = (r / 3) * 3 + (c / 3);
      
            return !_rows[r, val] && !_cols[c, val] && !_boxes[boxIdx, val];
        }

        private bool SolveRecursive()
        {
            int bestRow = -1;
            int bestCol = -1;
            int minOptions = 10; 

            bool foundEmpty = false;

            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if (_board[r, c] != 0) continue;

                    foundEmpty = true;
                    int options = CountOptions(r, c);

                    if (options == 0) return false; 

                    if (options < minOptions)
                    {
                        minOptions = options;
                        bestRow = r;
                        bestCol = c;
                        if (minOptions == 1) goto OptimizationFound; 
                    }
                }
            }

            if (!foundEmpty) return true; 

            OptimizationFound:

            for (int num = 1; num <= 9; num++)
            {
                if (IsSafe(bestRow, bestCol, num))
                {
                    _board[bestRow, bestCol] = num;
                    Mark(bestRow, bestCol, num, true);

                    if (SolveRecursive()) return true;

                    Mark(bestRow, bestCol, num, false);
                    _board[bestRow, bestCol] = 0;
                }
            }

            return false;
        }

        private int CountOptions(int r, int c)
        {
            int count = 0;
            int boxIdx = (r / 3) * 3 + (c / 3);

            for (int val = 1; val <= 9; val++)
            {
                if (!_rows[r, val] && !_cols[c, val] && !_boxes[boxIdx, val])
                    count++;
            }
            return count;
        }
    }
}