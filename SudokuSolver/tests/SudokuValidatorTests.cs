using Xunit;
using SudokuSolver;

namespace SudokuSolver.Tests
{
    public class SudokuValidatorTests
    {
        [Fact]
        public void IsValid_ValidBoard_ReturnsTrue()
        {
            int size = 9;
            SudokuBoard board = new SudokuBoard(size);

            board.SetCell(0, 0, 5);
            board.SetCell(0, 1, 3);
            board.SetCell(1, 0, 6);

            SudokuValidator validator = new SudokuValidator();
            bool result = validator.IsValid(board);

            Assert.True(result);
        }

        [Fact]
        public void IsValid_DuplicateInRow_ReturnsFalse()
        {
            int size = 9;
            SudokuBoard board = new SudokuBoard(size);

            board.SetCell(0, 0, 5);
            board.SetCell(0, 1, 5); // duplicate in row

            SudokuValidator validator = new SudokuValidator();
            bool result = validator.IsValid(board);

            Assert.False(result);
        }

        [Fact]
        public void IsValid_DuplicateInColumn_ReturnsFalse()
        {
            int size = 9;
            SudokuBoard board = new SudokuBoard(size);

            board.SetCell(0, 0, 7);
            board.SetCell(1, 0, 7); // duplicate in column

            SudokuValidator validator = new SudokuValidator();
            bool result = validator.IsValid(board);

            Assert.False(result);
        }

        [Fact]
        public void IsValid_DuplicateInBox_ReturnsFalse()
        {
            int size = 9;
            SudokuBoard board = new SudokuBoard(size);

            board.SetCell(0, 0, 9);
            board.SetCell(1, 1, 9); // duplicate in top-left 3x3 box

            SudokuValidator validator = new SudokuValidator();
            bool result = validator.IsValid(board);

            Assert.False(result);
        }
    }
}
