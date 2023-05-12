namespace SudokuSolver.Solver;
public class UniqueOptionInClumpStrategy : ISudokuSolverStrategy
{
    public bool Solve(Grid grid)
    {
        bool madeChanges = false;
        foreach (Clump clump in grid.Clumps)
        {
                madeChanges |= SetUniqueOption(clump);
        }
        return madeChanges;
    }
    private bool SetUniqueOption(Clump clump){
        var cells = clump.Cells;
            foreach (Cell cell in clump.Cells)
            {
                foreach (int availableOption in cell.AvailableOptions){
                    if (cells.Count(c => c.Id != cell.Id && c.AvailableOptions.Contains(availableOption)) == 0){
                        //available option is unique ->
                        cell.SetValue(availableOption);
                        return true;
                    }
                }
            }
            return false;
    }
}