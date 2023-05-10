namespace SudokuSolver;

public class PrintField
{
    public static void PrintCells(List<Cell> cells)
    {
        string output = "";
        string separator = ">-------+-------+-------<\n";
        for (int i = 0; i < 9; i++)
        {
            if (i % 3 == 0)
            {
                output += separator;
            }
            // for (int j = 0; j < 9; j ++){
            //     field 
            // }

            int cellId = i*9;
            output += $"| {cells[cellId]} {cells[cellId + 1]} {cells[cellId + 2]} | {cells[cellId + 3]} {cells[cellId + 4]} {cells[cellId + 5]} | {cells[cellId + 6]} {cells[cellId + 7]} {cells[cellId + 8]} |\n";
            if (i == 8){
                output += separator;
            }
        }
        Console.WriteLine(output);

    }
    
    public static void PrintValues(int[] values)
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
            // for (int j = 0; j < 9; j ++){
            //     field 
            // }

            int cellId = i*9;
            output += $"| {stringValues[cellId]} {stringValues[cellId + 1]} {stringValues[cellId + 2]} | {stringValues[cellId + 3]} {stringValues[cellId + 4]} {stringValues[cellId + 5]} | {stringValues[cellId + 6]} {stringValues[cellId + 7]} {stringValues[cellId + 8]} |\n";
            if (i == 8){
                output += separator;
            }
        }
        Console.WriteLine(output);

    }

}