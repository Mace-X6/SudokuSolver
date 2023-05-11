using FluentAssertions;

namespace SudokuSolver.Tests;
public class SolveTests
{
    [Fact]
    public void DuplicateOptionsSolver_Should_complete_sudoku_field()
    {
        int[] sudokuField = {
  1, 2, 3, 0, 0, 6, 0, 0, 9,
  0, 0, 0, 0, 0, 0, 4, 0, 0,
  0, 0, 0, 0, 0, 0, 5, 0, 0,
  0, 0, 0, 0, 0, 0, 0, 4, 0,
  0, 0, 0, 0, 0, 0, 0, 5, 0,
  0, 0, 0, 0, 0, 0, 0, 0, 0,
  0, 0, 0, 0, 0, 0, 0, 0, 0,
  0, 0, 0, 0, 0, 0, 0, 0, 0,
  0, 0, 0, 0, 0, 0, 0, 0, 0
        };
        
        var grid = new Grid();
        grid.FillGrid(sudokuField);
        Solve solve = new Solve();
        solve.DuplicateOptionsSolver(grid);
        grid.Cells[3].AvailableOptions.Should().BeEquivalentTo(new [] {4,5});
        grid.Cells[4].AvailableOptions.Should().BeEquivalentTo(new [] {4,5});
        grid.Cells[6].AvailableOptions.Should().BeEquivalentTo(new [] {7,8});
        grid.Cells[7].AvailableOptions.Should().BeEquivalentTo(new [] {7,8});

    }
}