using Xunit;
using SudokuSolver;
using System;

namespace SudokuSolver
{
    public class SudokuParserTests
    {
        [Fact]
        public void Parse_ValidString_ReturnsCorrectBoard()
        {
            string input = "530070000600195000098000060800060003400803001700020006060000280000419005000080079";
            int size = 9;

            SudokuParser parser = new SudokuParser(size);
            SudokuBoard board = parser.Parse(input);

            Assert.Equal(5, board.GetCell(0, 0));
            Assert.Equal(3, board.GetCell(0, 1));
            Assert.Equal(0, board.GetCell(0, 2));
            Assert.Equal(9, board.GetCell(8, 8));
        }

        [Fact]
        public void Parse_InvalidCharacter_ThrowsException()
        {
            string input = "53A070000600195000"; 
            int size = 4;

            SudokuParser parser = new SudokuParser(size);

            Assert.Throws<ArgumentException>(() => parser.Parse(input));
        }

        [Fact]
        public void Parse_NumberExceedsSize_ThrowsException()
        {
            string input = "5678"; 
            int size = 4;

            SudokuParser parser = new SudokuParser(size);

            Assert.Throws<ArgumentException>(() => parser.Parse(input));
        }
    }
}

