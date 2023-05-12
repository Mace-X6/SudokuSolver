using SudokuSolver;
using SudokuSolver.Solver;

int[] puzzle = new PuzzleGenerator().GeneratePuzzle(PuzzleDifficulty.Hard);

Console.WriteLine("before solving:");
Console.Write(puzzle.PrintAsSudokuGrid());

var grid = new Grid();
grid.FillGrid(puzzle);
// Console.Write(grid.PrintDebug());

var strategies = new ISudokuSolverStrategy[]
{
    new ExclusiveOptionsStrategy(),
    new UniqueOptionInClumpStrategy()
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