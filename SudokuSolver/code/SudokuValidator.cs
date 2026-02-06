namespace SudokuSolver
{
    internal class SudokuValidator
    {
        public bool IsValid(SudokuBoard board)
        {
            /// Checks whether the given Sudoku board is valid.
            /// A board is considered valid if:
            /// - Each row contains unique non-zero numbers.
            /// - Each column contains unique non-zero numbers.
            /// - Each sub-box contains unique non-zero numbers.
            /// Empty cells (value 0) are ignored.
            /// True if the board is valid according to Sudoku rules;
            /// false if any rule is violated.
            
            int size = board.Size;
            int boxSize = board.BoxSize;

            for (int r = 0; r < size; r++)
            {
                bool[] seen = new bool[size + 1];
                for (int c = 0; c < size; c++)
                {
                    int val = board.GetCell(r, c);
                    if (val == 0) continue;
                    if (seen[val]) return false;
                    seen[val] = true;
                }
            }

            for (int c = 0; c < size; c++)
            {
                bool[] seen = new bool[size + 1];
                for (int r = 0; r < size; r++)
                {
                    int val = board.GetCell(r, c);
                    if (val == 0) continue;
                    if (seen[val]) return false;
                    seen[val] = true;
                }
            }

            for (int boxRow = 0; boxRow < boxSize; boxRow++)
            {
                for (int boxCol = 0; boxCol < boxSize; boxCol++)
                {
                    bool[] seen = new bool[size + 1];
                    int startRow = boxRow * boxSize;
                    int startCol = boxCol * boxSize;

                    for (int r = 0; r < boxSize; r++)
                    {
                        for (int c = 0; c < boxSize; c++)
                        {
                            int val = board.GetCell(startRow + r, startCol + c);
                            if (val == 0) continue;
                            if (seen[val]) return false;
                            seen[val] = true;
                        }
                    }
                }
            }

            return true;
        }
    }
}