using System;

namespace SudokuSolver
{
  
    public class GenericSudokuSolver
    {
        /// A generic and efficient Sudoku solver that works with boards
        /// of any valid size (4x4, 9x9, 16x16, etc.).
        /// Uses bitmasking and backtracking with heuristics
        /// to efficiently solve the puzzle.
        
        private int _size;
        private int _boxSize;
        private int _totalCells;
        private int _fullMask;


        private int[] _rows;
        private int[] _cols;
        private int[] _boxes;
        private int[] _boardFlat;
        private int[] _cellToBox;
        private int[] _maskToValue;

        public GenericSudokuSolver(int size)
        {
            /// Creates a new GenericSudokuSolver for a given board size.
            _size = size;
            _boxSize = (int)Math.Sqrt(size);

            if (_boxSize * _boxSize != size)
                throw new ArgumentException("Size must be a perfect square (4, 9, 16, 25)");

            _totalCells = size * size;

            _fullMask = (1 << (_size + 1)) - 2;

            InitializeMemory();
        }

        private void InitializeMemory()
        {
            /// Initializes internal arrays and lookup tables used by the solver.
            _rows = new int[_size];
            _cols = new int[_size];
            _boxes = new int[_size];
            _boardFlat = new int[_totalCells];
            _cellToBox = new int[_totalCells];

            for (int i = 0; i < _totalCells; i++)
            {
                int r = i / _size;
                int c = i % _size;
                _cellToBox[i] = (r / _boxSize) * _boxSize + (c / _boxSize);
            }

            int arraySize = 1 << (_size + 1);
            _maskToValue = new int[arraySize];
            for (int i = 1; i <= _size; i++)
            {
                _maskToValue[1 << i] = i;
            }
        }

        public bool Solve(int[] inputBoard)
        /// Solves the given Sudoku board in-place.
        /// True if a solution was found; false otherwise.
        {
            if (inputBoard.Length != _totalCells)
                throw new ArgumentException($"Board must have {_totalCells} cells");

            Array.Clear(_rows, 0, _size);
            Array.Clear(_cols, 0, _size);
            Array.Clear(_boxes, 0, _size);

            for (int i = 0; i < _totalCells; i++)
            {
                int val = inputBoard[i];
                _boardFlat[i] = val;

                if (val != 0)
                {
                    int r = i / _size;
                    int c = i % _size;
                    int b = _cellToBox[i];
                    int mask = 1 << val;


                    if ((_rows[r] & mask) != 0 || (_cols[c] & mask) != 0 || (_boxes[b] & mask) != 0)
                        return false;

                    _rows[r] |= mask;
                    _cols[c] |= mask;
                    _boxes[b] |= mask;
                }
            }

            if (SolveRecursive())
            {
                Array.Copy(_boardFlat, inputBoard, _totalCells);
                return true;
            }

            return false;
        }

        private bool SolveRecursive() { 
          /// Recursive backtracking solver using the
          /// "minimum remaining values" heuristic.
            int bestIdx = -1;
            int minOptions = _size + 1;
            int bestMask = 0;

            for (int i = 0; i < _totalCells; i++)
            {
                if (_boardFlat[i] != 0) continue;

                int r = i / _size;
                int c = i % _size;
                int b = _cellToBox[i];

                int forbidden = _rows[r] | _cols[c] | _boxes[b];
                int allowed = ~forbidden & _fullMask;

                if (allowed == 0) return false;

                int count = CountSetBits(allowed);

                if (count < minOptions)
                {
                    minOptions = count;
                    bestIdx = i;
                    bestMask = allowed;
                    if (count == 1) break;
                }
            }

            if (bestIdx == -1) return true;

            int row = bestIdx / _size;
            int col = bestIdx % _size;
            int box = _cellToBox[bestIdx];

            int options = bestMask;
            while (options > 0)
            {
                int bit = options & (-options);
                options ^= bit;

                int num = _maskToValue[bit];

                _boardFlat[bestIdx] = num;
                _rows[row] |= bit;
                _cols[col] |= bit;
                _boxes[box] |= bit;

                if (SolveRecursive()) return true;

                _boardFlat[bestIdx] = 0;
                _rows[row] &= ~bit;
                _cols[col] &= ~bit;
                _boxes[box] &= ~bit;
            }

            return false;
        }

        private int CountSetBits(int n)
        /// Counts the number of set bits (1s) in an integer.
        {
            int count = 0;
            while (n > 0)
            {
                n &= (n - 1);
                count++;
            }
            return count;
        }
    }
}