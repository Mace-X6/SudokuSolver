using SudokuSolver;
using SudokuSolver.Solver;

// int[] sudokuField = {
//     5, 3, 0, 0, 0, 8, 9, 0, 2,
//     6, 0, 2, 1, 0, 5, 0, 4, 8,
//     0, 9, 0, 3, 4, 2, 5, 0, 0,
//     8, 0, 9, 0, 0, 1, 0, 2, 3,
//     0, 2, 0, 8, 5, 3, 7, 0, 1,
//     0, 1, 3, 0, 2, 4, 0, 5, 6,
//     9, 6, 0, 5, 0, 0, 2, 8, 0,
//     2, 8, 0, 4, 0, 9, 6, 0, 0,
//     3, 0, 0, 0, 8, 6, 0, 7, 9
// };

int[] puzzle_Easy =
{
    6, 3, 0, 0, 1, 0, 0, 0, 0,
    4, 0, 0, 0, 0, 0, 6, 0, 5,
    0, 0, 0, 8, 0, 9, 0, 0, 0,
    7, 0, 0, 0, 5, 3, 0, 2, 1,
    2, 0, 0, 7, 9, 1, 0, 0, 8,
    9, 4, 0, 6, 2, 0, 0, 0, 7,
    0, 0, 0, 1, 0, 5, 0, 0, 0,
    1, 0, 7, 0, 0, 0, 0, 0, 3,
    0, 0, 0, 0, 7, 0, 0, 4, 2
};

int[] puzzle_Medium =
{
    0, 5, 0, 0, 0, 0, 4, 2, 0,
    6, 2, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 3, 9, 2, 0, 5, 0, 0,
    0, 0, 0, 6, 7, 0, 0, 8, 0,
    4, 0, 0, 8, 0, 1, 0, 0, 0,
    0, 7, 8, 0, 4, 0, 6, 0, 0,
    0, 0, 4, 0, 0, 7, 8, 0, 0,
    1, 0, 0, 0, 9, 0, 0, 0, 5,
    5, 3, 7, 2, 0, 4, 0, 0, 0,
};

int[] puzzle_Hard =
{
    0, 0, 1, 0, 0, 4, 0, 7, 0,
    6, 4, 0, 2, 0, 0, 0, 0, 0,
    8, 0, 0, 0, 1, 0, 5, 0, 9,
    4, 0, 0, 0, 0, 2, 0, 0, 0,
    0, 0, 0, 1, 9, 0, 0, 8, 0,
    0, 0, 0, 7, 0, 0, 3, 0, 0,
    3, 0, 0, 5, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0, 7, 6, 0,
    9, 0, 0, 0, 7, 8, 4, 0, 0,
};

int[] puzzle_VeryHard =
{
    0, 0, 1, 0, 0, 6, 0, 0, 9,
    0, 3, 6, 9, 0, 0, 0, 4, 0,
    7, 0, 0, 3, 0, 0, 0, 8, 6,
    0, 0, 4, 0, 7, 0, 0, 0, 0,
    6, 0, 0, 1, 0, 9, 0, 0, 2,
    0, 0, 0, 0, 6, 0, 9, 0, 0,
    3, 5, 0, 0, 0, 7, 0, 0, 8,
    0, 6, 0, 0, 0, 1, 4, 2, 0,
    4, 0, 0, 6, 0, 0, 5, 0, 0
};

var puzzleToSolve = puzzle_Medium;

Console.WriteLine("before solving:");
PrintField.PrintValues(puzzleToSolve);

var grid = new Grid();
grid.FillGrid(puzzleToSolve);
// Console.Write(grid.PrintDebug());

var strategies = new ISudokuSolverStrategy[]
{
    new ExclusiveOptionsStrategy()
};

var solver = new SudokuSolver.Solver.SudokuSolver(strategies);
solver.Solve(grid);

if (grid.IsSolved)
{
    Console.WriteLine("\nSolved the puzzle!");
    Console.Write(grid.Print());
}
else
{
    Console.WriteLine("\nCould not solve the puzzle.");
    Console.Write(grid.PrintDebug());
}