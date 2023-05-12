namespace SudokuSolver;

public interface ISudokuSolverStrategy
{
    /// <summary>
    /// Tries to solve the specified grid. If any changes have been applied, it returns true.
    /// </summary>
    public bool Solve(Grid grid);
}