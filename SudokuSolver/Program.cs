using System;

namespace SudokuSolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SudokuParser parser = new SudokuParser();
            SudokuValidator validator = new SudokuValidator();
            SudokuSolver solver = new SudokuSolver();

            while (true)
            {
                Console.WriteLine("Enter sudoku string (81 chars) or 'exit':");
                string input = Console.ReadLine();

                if (input == null)
                    continue;

                if (input.ToLower() == "exit")
                    break;

                try
                {
                    SudokuBoard board = parser.Parse(input);

                    if (!validator.IsValid(board))
                    {
                        Console.WriteLine("Board is invalid.");
                        continue;
                    }

                    bool solved = solver.Solve(board);

                    if (!solved)
                    {
                        Console.WriteLine("Board has no solution.");
                        continue;
                    }

                    Console.WriteLine("Solved board:");
                    PrintBoard(board);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
