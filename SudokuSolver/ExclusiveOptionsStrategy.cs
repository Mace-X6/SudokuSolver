namespace SudokuSolver;

public class ExclusiveOptionsStrategy : ISudokuSolverStrategy
{
    public bool Solve(Grid grid)
    {
        bool changesApplied = false;
        
        foreach(Clump clump in grid.Clumps)
        {
            changesApplied = changesApplied || RemoveOptions(clump, 2);
            changesApplied = changesApplied || RemoveOptions(clump, 3);
            changesApplied = changesApplied || RemoveOptions(clump, 4);
            changesApplied = changesApplied || RemoveOptions(clump, 5);
            changesApplied = changesApplied || RemoveOptions(clump, 6);
        }

        return changesApplied;
    }

    private bool RemoveOptions(Clump clump, int count)
    {
        bool changesApplied = false;
        var cellsWithCountOptions = clump.Cells.Where(c => c.AvailableOptions.Count == count);

        foreach(var cell in cellsWithCountOptions)
        {
            var cellsWithMatchingOptions = FindCellsWithSameOptions(cell, clump).ToArray();

            bool numberOfCellsWithSameOptionsEqualsCount = cellsWithMatchingOptions.Length == count - 1;
            if (numberOfCellsWithSameOptionsEqualsCount)
            {
                var matchingCellIds = new List<int>() {cell.Id};
                matchingCellIds.AddRange(cellsWithMatchingOptions.Select(c => c.Id));

                var cellsToUpdate = clump.Cells.Where(c => !matchingCellIds.Contains(c.Id));
                foreach (var cellToUpdate in cellsToUpdate)
                {
                    changesApplied |= cellToUpdate.RemoveAvailableOptions(cell.AvailableOptions.ToArray());
                }
            }
        }

        return changesApplied;
    }

    private IEnumerable<Cell> FindCellsWithSameOptions(Cell cell, Clump clump)
    {
        foreach (var cellInClump in clump.Cells.Where(c => c.Id != cell.Id))
        {
            if (cellInClump.AvailableOptions.SequenceEqual(cell.AvailableOptions))
            { 
                yield return cellInClump;
            }
        }
    }
}