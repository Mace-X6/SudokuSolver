namespace SudokuSolver;
public class Solve
{
    public void DuplicateOptionsSolver(Grid grid){
        foreach(Clump clump in grid.Clumps)
        {
            RemoveOptions(clump, 2);
            RemoveOptions(clump, 3);
            RemoveOptions(clump, 4);
            RemoveOptions(clump, 5);
            RemoveOptions(clump, 6);
        }
    }

    private void RemoveOptions(Clump clump, int count)
    {
        var cellsWithCountOptions = clump.Cells.Where(c => c.AvailableOptions.Count == count);

        foreach(var cell in cellsWithCountOptions)
        {
            var cellsWithMatchingOptions = FindCellsWithSameOptions(cell, clump);

            if (cellsWithMatchingOptions.Count() > 0)
            {
                var matchingCellIds = new List<int>() {cell.Id};
                matchingCellIds.AddRange(cellsWithMatchingOptions.Select(c => c.Id));

                var cellsToUpdate = clump.Cells.Where(c => !matchingCellIds.Contains(c.Id));
                foreach (var cellToUpdate in cellsToUpdate)
                {
                    cellToUpdate.RemoveAvailableOptions(cell.AvailableOptions.ToArray());
                }
            }
        }
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