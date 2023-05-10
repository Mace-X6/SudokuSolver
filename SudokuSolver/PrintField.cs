namespace SudokuSolver;

public class PrintField
{
    public static void Print(List<Cell> cells)
    {
        string output = "";
        string separator = ">-----------------------<\n";
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
}