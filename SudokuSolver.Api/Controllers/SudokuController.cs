using Microsoft.AspNetCore.Mvc;
using Sudoku.Api;
using SudokuSolver.Solver;
using SudokuSolver = SudokuSolver.Solver.SudokuSolver;

namespace SudokuSolver.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SudokuController : ControllerBase
{
    private readonly ILogger<SudokuController> _logger;

    public SudokuController(ILogger<SudokuController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetPuzzle")]
    public SudokuGridDto Get()
    {
        var puzzle = new PuzzleGenerator().GeneratePuzzle(PuzzleDifficulty.Medium);
        
        var cells = puzzle
            .Select((value, index) => new SudokuCellDto
            {
                Id = index,
                Value = value,
                Options = value == 0 ? Enumerable.Range(1, 9).ToArray() : new[] { value }
            })
            .ToArray();

        return new SudokuGridDto
        {
            Cells = cells
        };
    }
    
    [HttpPost("SolvePuzzle")]
    public IActionResult SolvePuzzle([FromBody] int[] puzzle)
    {
        Grid grid = new Grid();
        grid.FillGrid(puzzle);
        
        new Solver.SudokuSolver(GetStrategies()).Solve(grid);

        return Ok(ConvertToDto(grid));
    }

    private SudokuGridDto ConvertToDto(Grid grid)
    {
        var gridDto = new SudokuGridDto
        {
            IsSolved = grid.IsSolved,
            Cells = grid.Cells.Select(c => new SudokuCellDto
            {
                Id = c.Id,
                Value = c.Value,
                Options = c.AvailableOptions.ToArray()
            }).ToArray()
        };

        return gridDto;
    }

    private static ISudokuSolverStrategy[] GetStrategies()
    {
        return new ISudokuSolverStrategy[]
        {
            new ExclusiveOptionsStrategy(),
//            new UniqueOptionInClumpStrategy()
        };
    }
}