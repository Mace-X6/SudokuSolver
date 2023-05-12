namespace SudokuSolver;

public class Cell
{
    private readonly bool isDebugMode;
    private readonly List<int> _availableOptions;
    public event EventHandler<CellValueChangedEvent>? AssignedMethod;
    public int Id { get; }

    public int[] AvailableOptions => _availableOptions.ToArray();

    public int Value => _availableOptions.Count == 1 ? _availableOptions[0] : 0;
    public bool IsSolved => Value != 0;
    
    public Cell(int cellId, bool isDebugMode = false)
    {
        this.isDebugMode = isDebugMode;
        Id = cellId;
        _availableOptions = Enumerable.Range(1, 9).ToList();
    }
    
    private void ValueChanged()
    {
        if (!isDebugMode)
        {
            AssignedMethod?.Invoke(this, new CellValueChangedEvent(Id, Value));
        }
    }
    public void SetValue(int value)
    {
        switch (value)
        {
            case 0:
                return;
            case >= 1 and <= 9:
                RemoveAvailableOptions(AvailableOptions.Where(opt => opt != value).ToArray());
                ValueChanged();
                break;
            default:
                throw new InvalidOperationException("the value given to SetValue is invalid");
        }
    }
    public bool RemoveAvailableOptions(int[] valuesToRemove)
    {
        bool appliedChanges = false;

        if (_availableOptions.Count > 1)
        {
            foreach (int value in valuesToRemove)
            {
                if (_availableOptions.Contains(value))
                {
                    _availableOptions.Remove(value);
                    appliedChanges = true;
                }
            }

            if (_availableOptions.Count == 1)
            {
                SetValue(_availableOptions[0]);
            }
        }

        return appliedChanges;
    }

    public override string ToString()
    {
        return IsSolved ? Value.ToString() : " ";
    }
}