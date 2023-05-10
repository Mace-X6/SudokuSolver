namespace SudokuSolverCs;
public class Cell
{
    public event EventHandler<CellValueChangedEvent>? AssignedMethod;
    public int Value { get; private set; }
    public int Id { get; }
    public List<int>? AvailableOptions { get; private set; }
    public Cell(int value, int cellId)
    {
        Id = cellId;
        Value = value;
        InitAvailableOptions();
    }
    private void ValueChanged()
    {
        AssignedMethod?.Invoke(this, new CellValueChangedEvent(Id, Value));
    }
    public int SetValue(int value)
    {
        if (value < 10 && value >= 0)
        {
            Value = value;
            ValueChanged();
        }
        else
        {
            throw new InvalidOperationException("the value given to SetValue is invalid");
        }
        return Value;
    }
    public List<int> RemoveAvailableOption(int value)
    {
        if (AvailableOptions.Count > 0)
        {
            AvailableOptions.Remove(value);
            if (AvailableOptions.Count == 1)
            {
                SetValue(AvailableOptions[0]);
            }
        }
        return AvailableOptions;
    }
    private void InitAvailableOptions()
    {
        if (CellIsEmpty())
        {
            List<int> availableOptions = new List<int>();
            for (int i = 1; i < 10; i++)
            {
                availableOptions.Add(i);
            }
        }
    }
    public bool CellIsEmpty()
    {
        if (Value == 0)
        {
            return true;
        }
        return false;
    }
}