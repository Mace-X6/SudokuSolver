using SudokuSolver;

// int[] sudokuField = {
//     5, 3, 0, 0, 0, 8, 9, 0, 2,
//     6, 0, 2, 1, 0, 5, 0, 4, 8,
//     0, 9, 0, 3, 4, 2, 5, 0, 0,
//     8, 0, 9, 0, 0, 1, 0, 2, 3,
//     0, 2, 0, 8, 5, 3, 7, 0, 1,
//     0, 1, 3, 0, 2, 4, 0, 5, 6,
//     9, 6, 0, 5, 0, 0, 2, 8, 0,
//     2, 8, 0, 4, 0, 9, 6, 0, 0,
//     3, 0, 0, 0, 8, 6, 0, 7, 9
// };

int[] sudokuField = {
    0, 2, 0, 0, 9, 0, 0, 0, 0,
    0, 0, 6, 4, 0, 2, 0, 0, 0,
    7, 0, 0, 0, 0, 0, 0, 0, 5,
    0, 0, 0, 0, 2, 0, 0, 3, 0,
    0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 3, 0, 0, 5, 0, 0, 0, 0,
    3, 0, 0, 0, 0, 0, 0, 0, 1,
    0, 0, 0, 6, 0, 7, 9, 0, 0,
    0, 0, 0, 0, 1, 0, 0, 2, 0
};

Console.WriteLine("before solving:");
PrintField.PrintValues(sudokuField);

var grid = new Grid();
var cells = grid.Cells;
grid.FillGrid(sudokuField);
Console.Write(grid.PrintDebug());

var solve = new Solve();
solve.DuplicateOptionsSolver(grid);
Console.WriteLine("\nafter solving:");
Console.Write(grid.Print());

Console.WriteLine("\nDebug Info:");
Console.Write(grid.PrintDebug());