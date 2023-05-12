namespace Sudoku.Api;

public class SudokuGridDto
{
    public SudokuCellDto[] Cells { get; set; } = new SudokuCellDto[81];
    public bool IsSolved { get; set; }
}

public class SudokuCellDto
{
    public int Id { get; set; }
    public int Value { get; set; }
    public int[] Options { get; set; } = new int[9];
}