using SudokuSolver;
using SudokuSolver.Solver;

int[] puzzleToSolve = Puzzles.Hard;

Console.WriteLine("before solving:");
Console.Write(puzzleToSolve.PrintAsSudokuGrid());

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