using FluentAssertions;

namespace SudokuSolver.Tests;

public class GridTests
{
    [Fact]
    public void When_grid_is_initialized_grid_cells_should_contain_no_duplicate_ids()
    {
        // Arrange
        var grid = new Grid();

        // Act
        var cells = grid.Cells;

        // Assert
        for (int i = 0; i < 81; i++)
        {
            var cell = cells[i];
            cell.Id.Should().Be(i);
        }
    }

    [Fact]
    public void When_blocks_are_initialized_they_should_contain_the_correct_values()
    {
        // Given
        var grid = new Grid();

        int[][] checkBlockArray = new int[][]
        {
            new[] {0, 1, 2, 9, 10, 11, 18, 19, 20},
            new[] {3, 4, 5, 12, 13, 14, 21, 22, 23},
            new[] {6, 7, 8, 15, 16, 17, 24, 25, 26},
            new[] {27, 28, 29, 36, 37, 38, 45, 46, 47},
            new[] {30, 31, 32, 39, 40, 41, 48, 49, 50},
            new[] {33, 34, 35, 42, 43, 44, 51, 52, 53},
            new[] {54, 55, 56, 63, 64, 65, 72, 73, 74},
            new[] {57, 58, 59, 66, 67, 68, 75, 76, 77},
            new[] {60, 61, 62, 69, 70, 71, 78, 79, 80},
        };

        // When
        var cells = grid.Cells;
        List<Clump> clumps = new List<Clump>();

        for (int i = 0; i < 9; i++)
        {
            clumps.Add(CellDistribute.Block(cells, i));
        }

        // Then
        for (int i = 0; i < clumps.Count; i++)
        {
            var cellsToCheck = clumps[i].Cells;
            foreach (var cell in cellsToCheck)
            {
                checkBlockArray[i].Should().Contain(cell.Id);
            }
        }
    }

    [Fact]
    public void When_the_sudoku_is_done_it_should_have_filled_all_possible_cells()
    {
        // Given
        var grid = new Grid();
        int[] sudokuField = {
    5, 3, 0, 0, 0, 8, 9, 0, 2,
    6, 0, 2, 1, 0, 5, 0, 4, 8,
    0, 9, 0, 3, 4, 2, 5, 0, 0,
    8, 0, 9, 0, 0, 1, 0, 2, 3,
    0, 2, 0, 8, 5, 3, 7, 0, 1,
    0, 1, 3, 0, 2, 4, 0, 5, 6,
    9, 6, 0, 5, 0, 0, 2, 8, 0,
    2, 8, 0, 4, 0, 9, 6, 0, 0,
    3, 0, 0, 0, 8, 6, 0, 7, 9
};

        // When
        grid.FillGrid(grid.Cells, sudokuField);

        // Then
        foreach (var cell in grid.Cells)
        {
            if (cell.Value == 0)
            {
                cell.AvailableOptions.Should().NotHaveCount(1);
            }
        }
    }

    [Fact]
    public void Clumps_should_never_have_one_empty_cell()
    {
        // Given
        var grid = new Grid();
        int[] sudokuField = {
    5, 3, 0, 0, 0, 8, 9, 0, 2,
    6, 0, 2, 1, 0, 5, 0, 4, 8,
    0, 9, 0, 3, 4, 2, 5, 0, 0,
    8, 0, 9, 0, 0, 1, 0, 2, 3,
    0, 2, 0, 8, 5, 3, 7, 0, 1,
    0, 1, 3, 0, 2, 4, 0, 5, 6,
    9, 6, 0, 5, 0, 0, 2, 8, 0,
    2, 8, 0, 4, 0, 9, 6, 0, 0,
    3, 0, 0, 0, 8, 6, 0, 7, 9
};

        // When
        grid.FillGrid(grid.Cells, sudokuField);

        // Then
        foreach (Clump clump in grid.Clumps)
        {
            int AmtOfEmptyCells = 0;
            foreach (Cell cell in clump.Cells)
            {
                if (cell.IsEmpty)
                {
                    AmtOfEmptyCells++;
                }
            }
            AmtOfEmptyCells.Should().NotBe(1);
        }
    }
    [Fact]
    public void TestName()
    {
        // Given
        var grid = new Grid();

        List<List<int>> rows = new List<List<int>>();
        for (int i = 0; i < 9; i++)
        {
            List<int> numbers = new List<int>();
            for (int j = 0; j < 9; j++)
            {
                numbers.Add(9 * i + j);
            }
            rows.Add(numbers);
        }

        // When
        var cells = grid.Cells;
        List<Clump> clumps = new List<Clump>();

        for (int i = 0; i < 9; i++)
        {
            clumps.Add(CellDistribute.Row(cells, i));
        }

        // Then
        for (var j = 0; j < 9; j ++)
        {
            Clump row = clumps[j];
            for (int i = 0; i < 9; i ++){
                row.Cells[i].Should().Be(rows[j][i]);
            }
        }
    }
}