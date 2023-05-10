namespace SudokuSolver;
public static class CellDistribute
{
    public static Clump Row(List<Cell> cells, int rowNum)
    {
        List<Cell> cellsToClump = new List<Cell>();
        for (int i = 9 * rowNum; i < 9 * (rowNum + 1) - 1; i++)
        {
            cellsToClump.Add(cells[i]);
        }

        Cell[] clumpCellArray = cellsToClump.ToArray();
        var clump = new Clump(clumpCellArray);
        return clump;
    }

    public static Clump Column(List<Cell> cells, int columnNum)
    {
        List<Cell> cellsToClump = new List<Cell>();

        for (int i = 0; i < 9; i++)
        {
            cellsToClump.Add(cells[columnNum + 9 * i]);
        }

        Cell[] clumpCellArray = cellsToClump.ToArray();
        var clump = new Clump(clumpCellArray);
        return clump;

    }

    public static Clump Block(List<Cell> cells, int blockNum)
    {
        int[] blockIndex = { blockNum / 3, blockNum % 3 };
        List<Cell> cellsToClump = new List<Cell>();

        for (int i = 0; i < 3; i++)//moving left to right
        {
            for (int j = 0; j < 3; j++)//moving top to bottom
            {
                cellsToClump.Add(cells[i + 3 * blockIndex[0] + 9 * j * blockIndex[1]]);
            }
        }

        Cell[] clumpCellArray = cellsToClump.ToArray();
        var clump = new Clump(clumpCellArray);
        return clump;
    }
}