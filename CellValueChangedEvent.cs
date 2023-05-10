namespace SudokuSolverCs;
public class CellValueChangedEvent
{
    public int CellId {get; private set;}
    public int NewValue {get; private set;}

    public CellValueChangedEvent(int cellId, int newValue){
        this.CellId = cellId;
        this.NewValue = newValue;
    }
}