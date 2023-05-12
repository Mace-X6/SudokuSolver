using FluentAssertions;
using SudokuSolver.Solver;

namespace SudokuSolver.Tests;
public class SolveTests
{
    [Fact]
    public void Exclusive_options_solver_should_solve_for_2_cells()
    {
        // Given
        var strategies = new ISudokuSolverStrategy[] {
            new Solver.ExclusiveOptionsStrategy()
        };
        Solver.SudokuSolver sudokuSolver = new Solver.SudokuSolver(strategies);
        int[] sudokuField = {
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0
        };
        Grid grid = new Grid(true);
        grid.FillGrid(sudokuField);

        // When
        grid.Cells[0].RemoveAvailableOptions(Enumerable.Range(3, 9).ToArray());
        grid.Cells[1].RemoveAvailableOptions(Enumerable.Range(3, 9).ToArray());

        sudokuSolver.Solve(grid);
        // Then
        grid.Cells[0].AvailableOptions.Should().Contain(new int[] { 1, 2 });
        grid.Cells[1].AvailableOptions.Should().Contain(new int[] { 1, 2 });
        grid.Cells[2].AvailableOptions.Should().NotContain(new int[] { 1, 2 });
        grid.Cells[3].AvailableOptions.Should().NotContain(new int[] { 1, 2 });
        grid.Cells[4].AvailableOptions.Should().NotContain(new int[] { 1, 2 });
        grid.Cells[5].AvailableOptions.Should().NotContain(new int[] { 1, 2 });
        grid.Cells[6].AvailableOptions.Should().NotContain(new int[] { 1, 2 });
        grid.Cells[7].AvailableOptions.Should().NotContain(new int[] { 1, 2 });
        grid.Cells[8].AvailableOptions.Should().NotContain(new int[] { 1, 2 });
    }

    [Fact]
    public void Exclusive_options_solver_should_solve_for_3_cells()
    {
        // Given
        var strategies = new ISudokuSolverStrategy[] {
            new Solver.ExclusiveOptionsStrategy()
        };
        Solver.SudokuSolver sudokuSolver = new Solver.SudokuSolver(strategies);
        int[] sudokuField = {
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0
        };
        Grid grid = new Grid(true);
        grid.FillGrid(sudokuField);

        // When
        grid.Cells[0].RemoveAvailableOptions(Enumerable.Range(4, 9).ToArray());
        grid.Cells[1].RemoveAvailableOptions(Enumerable.Range(4, 9).ToArray());
        grid.Cells[2].RemoveAvailableOptions(Enumerable.Range(4, 9).ToArray());

        sudokuSolver.Solve(grid);
        // Then
        grid.Cells[0].AvailableOptions.Should().Contain(new int[] { 1, 2, 3 });
        grid.Cells[1].AvailableOptions.Should().Contain(new int[] { 1, 2, 3 });
        grid.Cells[2].AvailableOptions.Should().Contain(new int[] { 1, 2, 3 });
        grid.Cells[3].AvailableOptions.Should().NotContain(new int[] { 1, 2, 3});
        grid.Cells[4].AvailableOptions.Should().NotContain(new int[] { 1, 2, 3});
        grid.Cells[5].AvailableOptions.Should().NotContain(new int[] { 1, 2, 3});
        grid.Cells[6].AvailableOptions.Should().NotContain(new int[] { 1, 2, 3});
        grid.Cells[7].AvailableOptions.Should().NotContain(new int[] { 1, 2, 3});
        grid.Cells[8].AvailableOptions.Should().NotContain(new int[] { 1, 2, 3});
    }

    [Fact]
    public void Unique_option_in_clump_strategy_should_solve_first_cell()
    {
        // Given
        var strategies = new ISudokuSolverStrategy[] {
            new Solver.UniqueOptionInClumpStrategy()
        };
        Solver.SudokuSolver sudokuSolver = new Solver.SudokuSolver(strategies);
        int[] sudokuField = {
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0
        };
        // When
        Grid grid = new Grid(true);
        grid.FillGrid(sudokuField);
        grid.Cells[1].RemoveAvailableOptions(new int[] { 1 });
        grid.Cells[2].RemoveAvailableOptions(new int[] { 1 });
        grid.Cells[3].RemoveAvailableOptions(new int[] { 1 });
        grid.Cells[4].RemoveAvailableOptions(new int[] { 1 });
        grid.Cells[5].RemoveAvailableOptions(new int[] { 1 });
        grid.Cells[6].RemoveAvailableOptions(new int[] { 1 });
        grid.Cells[7].RemoveAvailableOptions(new int[] { 1 });
        grid.Cells[8].RemoveAvailableOptions(new int[] { 1 });

        // Then
        sudokuSolver.Solve(grid);

        grid.Cells[0].Value.Should().Be(1);
        grid.Cells[1].Value.Should().Be(0);
        grid.Cells[2].Value.Should().Be(0);
        grid.Cells[3].Value.Should().Be(0);
        grid.Cells[4].Value.Should().Be(0);
        grid.Cells[5].Value.Should().Be(0);
        grid.Cells[6].Value.Should().Be(0);
        grid.Cells[7].Value.Should().Be(0);
        grid.Cells[8].Value.Should().Be(0);


    }
}