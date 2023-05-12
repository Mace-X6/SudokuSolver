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

    public Grid()
    {
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
                cell.SetValue(fields[cell.Id]);
            }
        }
    }
    
    public string Print()
    {
        const string separator = ">-------+-------+-------<\n";

        string output = "";

        for (int i = 0; i < 9; i++)
        {
            if (i % 3 == 0)
            {
                output += separator;
            }

            output+= Rows[i].Print();
        }

        output += separator;

        return output;
    }
    
    public string PrintDebug()
    {
        const string LineSeparator = ">-------+-------+-------+-------+-------+-------+-------+-------+-------<\n";
        const string FatLineSeparator = "=========================================================================\n";

        string output = FatLineSeparator;

        int rowIndex = 0;
        foreach (var row in Rows)
        {
            for (int cellInnerRowIndex = 0; cellInnerRowIndex < 3; cellInnerRowIndex++)
            {
                output += "║";

                int columnIndex = 0;
                foreach (var cell in row.Cells)
                {
                    output += $" {cell.PrintInnerRow(cellInnerRowIndex)}";

                    columnIndex++;
                    
                    if (columnIndex % 9 != 0)
                    {
                        if (columnIndex % 3 == 0)
                        {
                            output += "║";
                        }
                        else
                        {
                            output += "|";
                        }
                    }
                }
                output += "║\n";
            }

            rowIndex++;
            
            if (rowIndex % 9 != 0)
            {
                if (rowIndex % 3 == 0)
                {
                    output += FatLineSeparator;
                }
                else
                {
                    output += LineSeparator;
                }
            }
        }

        output += FatLineSeparator;
        return output;
    }
}