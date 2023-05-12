namespace SudokuSolver;

public class Cell
{
    public bool IsSolved => Value != 0;
    public event EventHandler<CellValueChangedEvent>? AssignedMethod;
    public int Value => AvailableOptions.Count == 1 ? AvailableOptions[0] : 0;
    public int Id { get; }
    public List<int> AvailableOptions { get; private set; }
    public Cell(int cellId, int value = 0)
    {
        Id = cellId;
        AvailableOptions = new List<int>();
        InitAvailableOptions();
    }
    private void ValueChanged()
    {
        AssignedMethod?.Invoke(this, new CellValueChangedEvent(Id, Value));
    }
    public void SetValue(int value, bool inDebugMode = false)
    {
        if (value < 10 && value >= 0)
        {
            if (value != 0)
            {
                RemoveAvailableOptions(AvailableOptions.Where(opt => opt != value).ToArray());
                if (!inDebugMode)
                {
                    ValueChanged();
                }
            }
        }
        else
        {
            throw new InvalidOperationException("the value given to SetValue is invalid");
        }
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

    public override string ToString()
    {
        return IsSolved ? Value.ToString() : " ";
    }
}