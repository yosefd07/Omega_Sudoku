using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    internal class SudokuParser
    {
        public SudokuBoard Parse(string input)
        {
            if (input == null)
                throw new ArgumentException("Input cannot be null");

            if (input.Length != 81)
                throw new ArgumentException("Input must contain exactly 81 characters");

            SudokuBoard board = new SudokuBoard();

            for (int i = 0; i < 81; i++)
            {
                if (input[i] < '0' || input[i] > '9')
                    throw new ArgumentException("Input contains invalid characters");

                int row = i / 9;
                int col = i % 9;
                int value = input[i] - '0';

                board.SetCell(row, col, value);
            }

            return board;
        }
    }
}
