using System;

namespace SudokuSolver
{
    internal class SudokuParser
    {
        private int _size;

        public SudokuParser(int size)
        {
            _size = size;
        }

        public SudokuBoard Parse(string input)
        {
            /// Parses a string input and creates a SudokuBoard from it.
            /// Each character in the string represents a cell in the board.
            /// Digits ('1'–'9') are converted to their numeric values,
            /// while any other character is treated as an empty cell (0).
            /// Return the sudoko board

            SudokuBoard board = new SudokuBoard(_size);

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                int value = 0;

                if (c >= '1' && c <= '9')
                {
                    value = c - '0';
                }
                else
                {
                    value = 0;
                }

                if (value > _size) value = 0;

                int row = i / _size;
                int col = i % _size;
                board.SetCell(row, col, value);
            }

            return board;
        }
    }
}