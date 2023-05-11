namespace SudokuSolver;
public class Grid
{
    private readonly List<Cell> _cells = new();
    public List<Clump> Clumps { get; private set; }

    private List<Clump> Rows { get; set; }
    private List<Clump> Columns { get; set; }
    private List<Clump> Blocks { get; set; }

    public Cell[] Cells => _cells.ToArray();

    public Grid()
    {
        Rows = new List<Clump>();
        Columns = new List<Clump>();
        Blocks = new List<Clump>();
        Clumps = new List<Clump>();

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

            Rows.Add(row);
            Columns.Add(column);
            Blocks.Add(block);
        }
        
        Clumps.AddRange(Rows);
        Clumps.AddRange(Columns);
        Clumps.AddRange(Blocks);
    }

    public Cell[] FillGrid(Cell[] cells, int[] field)
    {
        foreach (Cell cell in cells)
        {
            if (cell.IsEmpty)
            {
                cell.SetValue(field[cell.Id]);
            }
        }
        return cells;
    }
}