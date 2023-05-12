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
            if (value != 0)
            {
                ValueChanged();
            }
        }
        else
        {
            throw new InvalidOperationException("the value given to SetValue is invalid");
        }
        return Value;
    }
    public bool RemoveAvailableOptions(int[] valuesToRemove)
    {
        bool appliedChanges = false;
        
        if (AvailableOptions?.Count > 1)
        {
            foreach (int value in valuesToRemove)
            {
                if (AvailableOptions.Contains(value))
                {
                    AvailableOptions.Remove(value);
                    appliedChanges = true;
                }
            }

            if (AvailableOptions.Count == 1)
            {
                SetValue(AvailableOptions[0]);
            }
        }

        return appliedChanges;
    }
    private void InitAvailableOptions()
    {
        if (!IsSolved)
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
    public bool IsSolved => Value != 0;
    
    public string Print()
    {
        return IsSolved ? Value.ToString() : " ";
    }
    
    public override string ToString()
    {
        return IsSolved ? Value.ToString() : " ";
    }

    public string PrintInnerRow(int innerRowIndex)
    {
        if (!IsSolved)
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