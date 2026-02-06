# C# High-Performance Sudoku Solver

A generic, high-performance Sudoku solver written in C#. This project is designed to be flexible (supporting different board sizes) and extremely fast, utilizing bitwise operations and the MRV (Minimum Remaining Values) heuristic.

##  Features

* **Generic Architecture:** Supports standard 9x9 Sudoku, as well as 4x4, and could support more.
* **High Performance:** Uses bitmasking and backtracking optimizations to solve hard puzzles in milliseconds.
* **Input Validation:** Validates Sudoku rules (rows, columns, boxes) before attempting to solve.
* **Dynamic UI:** The console output adjusts automatically to the board size.

## 🛠️ Configuration

To change the Sudoku size, modify the constant in `Program.cs`:

```c sharp
// Program.cs
private const int BoardSize = 9; // Change to 4 or 9