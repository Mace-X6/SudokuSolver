namespace SudokuSolver;

public static class SudokuPrintExtensions
{
    public static string PrintAsSudokuGrid(this int[] values)
    {
        string output = "";
        string separator = ">-------+-------+-------<\n";
        List<string> stringValues = new List<string>();
        for (int i = 0; i < values.Length; i ++){
            stringValues.Add(values[i] == 0 ? " " : values[i].ToString());
        }
        for (int i = 0; i < 9; i++)
        {
            if (i % 3 == 0)
            {
                output += separator;
            }

            int cellId = i*9;
            output += $"| {stringValues[cellId]} {stringValues[cellId + 1]} {stringValues[cellId + 2]} | {stringValues[cellId + 3]} {stringValues[cellId + 4]} {stringValues[cellId + 5]} | {stringValues[cellId + 6]} {stringValues[cellId + 7]} {stringValues[cellId + 8]} |\n";
            if (i == 8){
                output += separator;
            }
        }
        return output;
    }

    public static string Print(this Grid grid)
    {
        const string separator = ">-------+-------+-------<\n";

        string output = "";

        for (int i = 0; i < 9; i++)
        {
            if (i % 3 == 0)
            {
                output += separator;
            }

            output+= grid.Rows[i].Print();
        }

        output += separator;

        return output;
    }
    
    public static string PrintDebug(this Grid grid)
    {
        const string LineSeparator = ">-------+-------+-------+-------+-------+-------+-------+-------+-------<\n";
        const string FatLineSeparator = "=========================================================================\n";

        string output = FatLineSeparator;

        int rowIndex = 0;
        foreach (var row in grid.Rows)
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

    private static string Print(this Row row)
    {
        return $"| " +
               $"{row.Cells[0].Print()} {row.Cells[1].Print()} {row.Cells[2].Print()} | " +
               $"{row.Cells[3].Print()} {row.Cells[4].Print()} {row.Cells[5].Print()} | " +
               $"{row.Cells[6].Print()} {row.Cells[7].Print()} {row.Cells[8].Print()} " +
               $"|\n";
    }


    private static string Print(this Cell cell)
    {
        return cell.IsSolved ? cell.Value.ToString() : " ";
    }

    private static string PrintInnerRow(this Cell cell, int innerRowIndex)
    {
        if (!cell.IsSolved)
        {
            int offset = innerRowIndex * 3;
            return $"{cell.PrintOption(1 + offset)} {cell.PrintOption(2 + offset)} {cell.PrintOption(3 + offset)} ";
        }
        
        if (innerRowIndex == 1)
        {
            return $"  {cell.Value}   ";
        }

        return "      ";
    }

    private static string PrintOption(this Cell cell, int optionValue)
    {
        return cell.AvailableOptions.Contains(optionValue) ? $"{optionValue}" : " ";
    }
}