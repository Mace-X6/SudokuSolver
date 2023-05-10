namespace SudokuSolver;

public class Clump
{
    public Cell[] Cells { get; }
    
    public Clump(Cell[] cells){
        Cells = cells;
        foreach (Cell cell in Cells){
            cell.AssignedMethod += UpdateCells;
        }
    }
    private void UpdateCells(object? sender, CellValueChangedEvent cellValueChangedEvent){
        foreach (Cell cell in Cells){
            if (cell.Id != cellValueChangedEvent.CellId){
                cell.RemoveAvailableOption(cellValueChangedEvent.NewValue);
            }
        }
    }
}