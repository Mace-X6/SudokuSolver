using SudokuSolver;
using SudokuSolver.Solver;

PuzzleDifficulty difficulty = PuzzleDifficulty.Expert;

int[] puzzle = new PuzzleGenerator().GeneratePuzzle(difficulty);

var grid = new Grid();
grid.FillGrid(puzzle);
int originalUnsolvedCount = grid.UnsolvedCount;

Console.WriteLine($"Puzzle ({difficulty}, {originalUnsolvedCount} open cells):");
Console.Write(puzzle.PrintAsSudokuGrid());

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
    Console.WriteLine($"\nCould not solve the {difficulty} puzzle. {grid.UnsolvedCount} unsolved cells remain.");
    Console.Write(grid.PrintDebug());
}