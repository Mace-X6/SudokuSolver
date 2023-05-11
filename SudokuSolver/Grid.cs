namespace SudokuSolver;
public class Grid
{
    public List<Clump> Rows { get; private set; }
    public List<Clump> Columns { get; private set; }
    public List<Clump> Blocks { get; private set; }
    public List<Clump> Clumps { get; private set; }
    public List<Cell> Cells { get; private set; }
    public Grid()
    {
        Cells = new List<Cell>();
        Rows = new List<Clump>();
        Columns = new List<Clump>();
        Blocks = new List<Clump>();
        Clumps = new List<Clump>();

        for (int id = 0; id < 81; id++)
        {
            var cell = new Cell(id);
            Cells.Add(cell);
        }

        for (int j = 0; j < 9; j++)
        {
            var row = CellDistribute.Row(Cells, j);
            var column = CellDistribute.Column(Cells, j);
            var block = CellDistribute.Block(Cells, j);
            Rows.Add(row);
            Columns.Add(column);
            Blocks.Add(block);
            Clumps.Add(row);
            Clumps.Add(column);
            Clumps.Add(block);


        }
    }

    public List<Cell> FillGrid(List<Cell> cells, int[] field)
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