namespace SudokuSolver;

public class PrintField
{
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

            int cellId = i*9;
            output += $"| {stringValues[cellId]} {stringValues[cellId + 1]} {stringValues[cellId + 2]} | {stringValues[cellId + 3]} {stringValues[cellId + 4]} {stringValues[cellId + 5]} | {stringValues[cellId + 6]} {stringValues[cellId + 7]} {stringValues[cellId + 8]} |\n";
            if (i == 8){
                output += separator;
            }
        }
        Console.WriteLine(output);

    }
}