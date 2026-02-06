using System;

namespace SudokuSolver
{
    internal class SudokuBoard
    {
   
        
        public int Size { get; private set; }
        /// Size of the board
        public int BoxSize { get; private set; }
        /// Size of each sub-box
        private int[] _grid; 

        public SudokuBoard(int size)
        {
         /// Creates a new SudokuBoard with the given size.
            
            Size = size;
            BoxSize = (int)Math.Sqrt(size);

            if (BoxSize * BoxSize != size)
                throw new ArgumentException("Board size must be a perfect square (4, 9, 16, 25)");

            _grid = new int[size * size];
        }

        public int GetCell(int row, int col)
        {
            /// Gets the value of a specific cell.
            return _grid[row * Size + col];
        }

        public void SetCell(int row, int col, int value)
        {
            /// Sets the value of a specific cell.
            _grid[row * Size + col] = value;
        }

        public int[] GetFlatArray()
        {
            /// Returns a copy of the board as a flat array.

            int[] copy = new int[_grid.Length];
            Array.Copy(_grid, copy, _grid.Length);
            return copy;
        }

        public void UpdateFromFlatArray(int[] solvedArray)
        {
            /// Updates the board using a flat array representation.
            if (solvedArray.Length != _grid.Length) throw new ArgumentException("Array size mismatch");
            Array.Copy(solvedArray, _grid, _grid.Length);
        }
    }
}