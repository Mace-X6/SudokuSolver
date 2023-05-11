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
        AvailableOptions = new List<int>();
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
    
    public string Print()
    {
        return IsEmpty ? " " : Value.ToString();
    }
    
    public override string ToString()
    {
        return IsEmpty ? " " : Value.ToString();
    }

    public string PrintInnerRow(int innerRowIndex)
    {
        /*
| 1 2 3 |
| 4 5 6 |
| 7 8 9 |
         */
        
        if (IsEmpty)
        {
            int optionValueOffset = innerRowIndex * 3;
            return $"{PrintOption(1 + optionValueOffset)} {PrintOption(2 + optionValueOffset)} {PrintOption(3 + optionValueOffset)} ";
        }
        
        if (innerRowIndex == 1)
        {
            return $"  {Value}   ";
        }

        return "      ";
    }

    private string PrintOption(int optionValue)
    {
        return AvailableOptions.Contains(optionValue) ? $"{optionValue}" : " ";
    }
}