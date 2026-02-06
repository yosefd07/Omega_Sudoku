using System;

namespace SudokuSolver
{
    internal class BoardPrinter
    {
        public void PrintBoard(SudokuBoard board)
        /// Prints the given Sudoku board to the console.
        /// Empty cells (value 0) are displayed as dots (.),
        /// and lines are drawn to separate Sudoku sub-boxes.
        
        {
            int size = board.Size;
            int boxSize = board.BoxSize;

            string horizontalLine = new string('-', (size * 2) + (size / boxSize) * 2);

            for (int row = 0; row < size; row++)
            {
                if (row % boxSize == 0 && row != 0)
                    Console.WriteLine(horizontalLine);

                for (int col = 0; col < size; col++)
                {
                    if (col % boxSize == 0 && col != 0)
                        Console.Write("| ");

                    int value = board.GetCell(row, col);

                    Console.Write(value == 0 ? ". " : value + " ");
                }

                Console.WriteLine();
            }
        }
    }
}