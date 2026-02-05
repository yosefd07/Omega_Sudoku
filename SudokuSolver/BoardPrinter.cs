using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    internal class BoardPrinter
    {
            
           public void PrintBoard(SudokuBoard board)
        {
            for (int row = 0; row < 9; row++)
            {
                if (row % 3 == 0 && row != 0)
                    Console.WriteLine("------+-------+------");

                for (int col = 0; col < 9; col++)
                {
                    if (col % 3 == 0 && col != 0)
                        Console.Write("| ");

                    int value = board.GetCell(row, col);
                    Console.Write(value == 0 ? ". " : value + " ");
                }

                Console.WriteLine();
            }
        }

    }

}
