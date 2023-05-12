namespace SudokuSolver.Solver
{
    public class SudokuSolver
    {
        private readonly IEnumerable<ISudokuSolverStrategy> strategies;

        public SudokuSolver(IEnumerable<ISudokuSolverStrategy> strategies)
        {
            this.strategies = strategies;
        }

        public void Solve(Grid grid)
        {
            bool changesApplied;

            do
            {
                changesApplied = ApplyStrategies(grid);
            } while (changesApplied);
        }

        private bool ApplyStrategies(Grid grid)
        {
            bool changesApplied = false;
            
            foreach (var strategy in strategies)
            {
                changesApplied = changesApplied || strategy.Solve(grid);
            }

            return changesApplied;
        }
    }
}