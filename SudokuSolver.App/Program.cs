using SudokuSolver;
using SudokuSolver.Solver;

PuzzleDifficulty difficulty = PuzzleDifficulty.Expert;

int[] puzzle = new PuzzleGenerator().GeneratePuzzle(difficulty);

Console.WriteLine($"Puzzle ({difficulty}):");
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
    Console.WriteLine($"\nCould not solve the {difficulty} puzzle.");
    Console.Write(grid.PrintDebug());
}