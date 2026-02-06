using System;
using System.Diagnostics;

namespace SudokuSolver
{
    internal class Program
    {
        private const int BoardSize = 9;
        //choosing the sudoku kind you want to play

        static void Main(string[] args)
        {
            BoardPrinter boardPrinter = new BoardPrinter();
            SudokuParser parser = new SudokuParser(BoardSize);
            SudokuValidator validator = new SudokuValidator();
            GenericSudokuSolver solver = new GenericSudokuSolver(BoardSize);

            int inputLength = BoardSize * BoardSize;

            while (true)
            {
                Console.WriteLine($"\n==========================================");
                Console.WriteLine($"Enter sudoku string ({inputLength} digits) or 'exit':");

                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input)) continue;
                if (input.ToLower() == "exit") break;

                if (input.Length != inputLength)
                {
                    Console.WriteLine($"Error: Expected {inputLength} digits, got {input.Length}.");
                    continue;
                }

                Stopwatch sw = Stopwatch.StartNew();

                try
                {
                    SudokuBoard board = parser.Parse(input);

                    if (!validator.IsValid(board))
                    {
                        Console.WriteLine("Board is invalid.");
                        continue;
                    }

                    Console.WriteLine("Original board:");
                    boardPrinter.PrintBoard(board);

                    int[] flatBoard = board.GetFlatArray();
                    bool solved = solver.Solve(flatBoard);

                    if (solved)
                    {
                        board.UpdateFromFlatArray(flatBoard);
                        Console.WriteLine("\nSolved board:");
                        boardPrinter.PrintBoard(board);
                    }
                    else
                    {
                        Console.WriteLine("Board has no solution.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                sw.Stop();
                Console.WriteLine($"Time: {sw.Elapsed.TotalSeconds:F4} sec");
            }
        }
    }
}