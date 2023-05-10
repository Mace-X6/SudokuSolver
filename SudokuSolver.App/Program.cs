using SudokuSolver;

int[] sudokuField = {
    5, 3, 4, 6, 7, 8, 9, 1, 2,
    6, 7, 2, 1, 9, 5, 3, 4, 8,
    1, 9, 8, 3, 4, 2, 5, 6, 7,
    8, 5, 9, 7, 6, 1, 4, 2, 3,
    4, 2, 6, 8, 5, 3, 7, 9, 1,
    7, 1, 3, 0, 2, 4, 8, 5, 6,
    9, 6, 1, 5, 3, 7, 2, 8, 4,
    2, 8, 7, 4, 1, 9, 6, 3, 5,
    3, 4, 5, 2, 8, 6, 1, 7, 9
};
var cells = InitializeGrid();
cells = FillGrid(cells, sudokuField);
PrintField.Print(cells);

static List<Cell> InitializeGrid()
{
    List<Cell> cells = new List<Cell>();
    for (int id = 0; id < 81; id++){
        var cell = new Cell(id);
        cells.Add(cell);
    }

    List<Clump> clumps = new List<Clump>();
    for (int j = 0; j < 9; j ++){
        clumps.Add(CellDistribute.Row(cells, j));
        clumps.Add(CellDistribute.Column(cells, j));
        clumps.Add(CellDistribute.Block(cells, j));
    }

    return cells;
}

static List<Cell> FillGrid(List<Cell> cells, int[] field){
    foreach (Cell cell in cells){
        if (cell.IsEmpty){
            cell.SetValue(field[cell.Id]);
        }
    }
    return cells;
}