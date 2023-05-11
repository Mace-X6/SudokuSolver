namespace SudokuSolver;

public class Cell
{
    public event EventHandler<CellValueChangedEvent>? AssignedMethod;
    public int Value { get; private set; }
    public int Id { get; }
    public List<int> AvailableOptions { get; private set; }
    public Cell(int cellId, int value = 0)
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
    public void RemoveAvailableOptions(int[] valuesToRemove)
    {
        if (AvailableOptions?.Count > 1)
        {
            foreach (int value in valuesToRemove)
            {
                AvailableOptions.Remove(value);
            }

            if (AvailableOptions.Count == 1)
            {
                SetValue(AvailableOptions[0]);
            }
        }
    }
    private void InitAvailableOptions()
    {
        AvailableOptions = new List<int>();
        if (this.IsEmpty)
        {
            for (int i = 1; i < 10; i++)
            {
                AvailableOptions.Add(i);
            }
        }
        else
        {
            AvailableOptions.Add(Value);
        }
    }
    public bool IsEmpty => Value == 0;

    public override string ToString()
    {
        return IsEmpty ? " " : Value.ToString();
    }
}