namespace SudokuSolver;
public class Grid
{
    private readonly List<Cell> _cells = new();
    private readonly List<Row> _rows = new();
    private readonly List<Column> _columns = new();
    private readonly List<Block> _blocks = new();
    private readonly List<Clump> _clumps = new();

    public Clump[] Clumps => _clumps.ToArray();
    public Row[] Rows => _rows.ToArray();
    public Column[] Columns => _columns.ToArray();
    public Block[] Blocks => _blocks.ToArray();
    public Cell[] Cells => _cells.ToArray();
    public bool IsSolved => _cells.All(c => c.IsSolved);

    private bool IsDebugMode { get; }

    public Grid(bool isDebugMode = false)
    {
        IsDebugMode = isDebugMode;
        for (int id = 0; id < 81; id++)
        {
            var cell = new Cell(id);
            _cells.Add(cell);
        }

        for (int j = 0; j < 9; j++)
        {
            var row = new Row(j, Cells);
            var column = new Column(j, Cells);
            var block = new Block(j, Cells);

            _rows.Add(row);
            _columns.Add(column);
            _blocks.Add(block);
        }

        _clumps.AddRange(_rows);
        _clumps.AddRange(_columns);
        _clumps.AddRange(_blocks);
    }

    public void FillGrid(int[] fields)
    {
        foreach (Cell cell in Cells)
        {
            if (!cell.IsSolved)
            {
                cell.SetValue(fields[cell.Id], IsDebugMode);
            }
        }
    }
}