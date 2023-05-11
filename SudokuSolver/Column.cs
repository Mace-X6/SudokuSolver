namespace SudokuSolver;

public class Column : Clump
{
    public Column(int number, Cell[] gridCells) : base(number, gridCells)
    {
    }

    protected override Cell[] FilterClumpCells(Cell[] gridCells)
    {
        var cellsToClump = new List<Cell>();

        for (int i = 0; i < 9; i++)
        {
            cellsToClump.Add(gridCells[Number + 9 * i]);
        }

        return cellsToClump.ToArray();
    }
}