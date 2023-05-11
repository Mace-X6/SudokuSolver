namespace SudokuSolver;
public class SudokuSolve
{
    public Grid DuplicateOptionsSolver(Grid grid){
        foreach(Clump clump in grid.Clumps)
        {
            Cell[][] duplicateAvaialableOptionCells = GetDuplicateAvaialableOptionCells(clump.Cells);
            foreach (Cell[] matchingCells in duplicateAvaialableOptionCells)
            {
                foreach (Cell cell in clump.Cells){
                    if (!matchingCells.Contains(cell)){
                        foreach (int value in matchingCells[0].AvailableOptions)
                        {
                        cell.RemoveAvailableOption(value);
                        }
                    }
                }
            }
        }
        return grid;
    }
    private Cell[][] GetDuplicateAvaialableOptionCells(Cell[] cells)
    {
        List<List<Cell>> matchingCellsList = new();
        foreach (Cell cell in cells)
        {
            foreach(List<Cell> matchingCells in matchingCellsList){
                if (matchingCells.Contains(cell)){
                    continue;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                List<Cell> matchingCells = new();
                if (cells[i].Id != cell.Id)
                {
                    Cell targetCell = cells[i];
                    if (targetCell.AvailableOptions == cell.AvailableOptions)
                    {
                        if (!matchingCells.Contains(cell)){
                            matchingCells.Add(cell);
                        }
                        matchingCells.Add(targetCell);
                    }
                }
            }
        }
        Cell[][] output = new Cell[matchingCellsList.Count][];
        for (int i = 0; i < matchingCellsList.Count; i ++){
            output[i] = matchingCellsList[i].ToArray();
        }
        return output;
    }
}