namespace SudokuSolver;

public class Row : Clump
{
    public Row(int number, Cell[] gridCells) : base(number, gridCells)
    {
    }

    protected override Cell[] FilterClumpCells(Cell[] gridCells)
    {
        var cellsToClump = new List<Cell>();
        for (int i = 9 * Number; i < 9 * (Number + 1); i++)
        {
            cellsToClump.Add(gridCells[i]);
        }

        return cellsToClump.ToArray();
    }
    
    public string Print()
    {
        return $"| {Cells[0]} {Cells[1]} {Cells[2]} | {Cells[3]} {Cells[4]} {Cells[5]} | {Cells[6]} {Cells[7]} {Cells[8]} |\n";
    }
}