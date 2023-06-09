﻿namespace SudokuSolver;

public abstract class Clump
{
    public int Number { get; }
    public Cell[] Cells { get; private set; }
    
    protected Clump(int number, Cell[] gridCells)
    {
        Number = number;
        Cells = Array.Empty<Cell>();
        
        InitializeCells(gridCells);
    }

    private void InitializeCells(IEnumerable<Cell> gridCells)
    {
        Cells = FilterClumpCells(gridCells.ToArray());
        
        foreach (Cell cell in Cells){
            cell.AssignedMethod += UpdateCells;
        }
    }

    protected abstract Cell[] FilterClumpCells(Cell[] gridCells);

    private void UpdateCells(object? sender, CellValueChangedEvent cellValueChangedEvent){
        foreach (Cell cell in Cells){
            if (cell.Id != cellValueChangedEvent.CellId){
                cell.RemoveAvailableOptions(new [] { cellValueChangedEvent.NewValue });
            }
        }
    }
}