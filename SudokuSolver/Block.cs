namespace SudokuSolver;

public class Block : Clump
{
    public Block(int number, Cell[] gridCells) : base(number, gridCells)
    {
    }

    protected override Cell[] FilterClumpCells(Cell[] gridCells)
    {
        var cellsToClump = new List<Cell>();
        
        int start = Number * 3 + (Number / 3) * 18;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int index = start + j + i * 9;
                cellsToClump.Add(gridCells.ElementAt(index));
            }
        }

        return cellsToClump.ToArray();
    }
}