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
        return $"| " +
               $"{Cells[0].Print()} {Cells[1].Print()} {Cells[2].Print()} | " +
               $"{Cells[3].Print()} {Cells[4].Print()} {Cells[5].Print()} | " +
               $"{Cells[6].Print()} {Cells[7].Print()} {Cells[8].Print()} " +
               $"|\n";
    }
}