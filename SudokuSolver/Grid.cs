namespace SudokuSolver;
public class Grid
{
    public List<Clump> Rows { get; private set; }
    public List<Clump> Columns { get; private set; }
    public List<Clump> Blocks { get; private set; }
    public List<Cell> Cells { get; private set; }
    public Grid()
    {
        Cells = new List<Cell>();
        Rows = new List<Clump>();
        Columns = new List<Clump>();
        Blocks = new List<Clump>();

        for (int id = 0; id < 81; id++)
        {
            var cell = new Cell(id);
            Cells.Add(cell);
        }

        for (int j = 0; j < 9; j++)
        {

            Rows.Add(CellDistribute.Row(Cells, j));
            Columns.Add(CellDistribute.Column(Cells, j));
            Blocks.Add(CellDistribute.Block(Cells, j));
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