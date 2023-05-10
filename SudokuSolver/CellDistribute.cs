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
        List<Cell> cellsToClump = new List<Cell>();
        
        int start = blockNum * 3 + (blockNum / 3) * 18;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int index = start + j + i * 9;
                cellsToClump.Add(cells[index]);
            }
        }

        Cell[] clumpCellArray = cellsToClump.ToArray();
        var clump = new Clump(clumpCellArray);
        return clump;
    }
}