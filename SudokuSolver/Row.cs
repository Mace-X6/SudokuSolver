﻿namespace SudokuSolver;

public class Row : Clump
{
    public Row(int number, Cell[] gridCells) : base(number, gridCells)
    {
    }

    protected override Cell[] FilterClumpCells(Cell[] gridCells)
    {
        var cellsToClump = new List<Cell>();
        for (int i = 9 * Number; i < 9 * (Number + 1); i++)
        {
            cellsToClump.Add(gridCells[i]);
        }

        return cellsToClump.ToArray();
    }
}