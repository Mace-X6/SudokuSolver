namespace SudokuSolver;

public enum PuzzleDifficulty
{
    Easy,
    Medium,
    Hard,
    Expert
}

public class PuzzleGenerator
{
    public int[] GeneratePuzzle(PuzzleDifficulty difficulty)
    {
        switch (difficulty)
        {
            case PuzzleDifficulty.Easy:
                return Puzzles.Easy;
            case PuzzleDifficulty.Medium:
                return Puzzles.Medium;
            case PuzzleDifficulty.Hard:
                return Puzzles.Hard;
            case PuzzleDifficulty.Expert:
                return Puzzles.VeryHard;
            default:
                throw new ArgumentOutOfRangeException(nameof(difficulty), difficulty, null);
        }
    }
}

internal static class Puzzles
{
    public static int[] Easy =
    {
        6, 3, 0, 0, 1, 0, 0, 0, 0,
        4, 0, 0, 0, 0, 0, 6, 0, 5,
        0, 0, 0, 8, 0, 9, 0, 0, 0,
        7, 0, 0, 0, 5, 3, 0, 2, 1,
        2, 0, 0, 7, 9, 1, 0, 0, 8,
        9, 4, 0, 6, 2, 0, 0, 0, 7,
        0, 0, 0, 1, 0, 5, 0, 0, 0,
        1, 0, 7, 0, 0, 0, 0, 0, 3,
        0, 0, 0, 0, 7, 0, 0, 4, 2
    };

    public static int[] Medium =
    {
        0, 5, 0, 0, 0, 0, 4, 2, 0,
        6, 2, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 3, 9, 2, 0, 5, 0, 0,
        0, 0, 0, 6, 7, 0, 0, 8, 0,
        4, 0, 0, 8, 0, 1, 0, 0, 0,
        0, 7, 8, 0, 4, 0, 6, 0, 0,
        0, 0, 4, 0, 0, 7, 8, 0, 0,
        1, 0, 0, 0, 9, 0, 0, 0, 5,
        5, 3, 7, 2, 0, 4, 0, 0, 0,
    };

    public static int[] Hard =
    {
        0, 0, 1, 0, 0, 4, 0, 7, 0,
        6, 4, 0, 2, 0, 0, 0, 0, 0,
        8, 0, 0, 0, 1, 0, 5, 0, 9,
        4, 0, 0, 0, 0, 2, 0, 0, 0,
        0, 0, 0, 1, 9, 0, 0, 8, 0,
        0, 0, 0, 7, 0, 0, 3, 0, 0,
        3, 0, 0, 5, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 7, 6, 0,
        9, 0, 0, 0, 7, 8, 4, 0, 0,
    };

    public static int[] VeryHard =
    {
        0, 0, 1, 0, 0, 6, 0, 0, 9,
        0, 3, 6, 9, 0, 0, 0, 4, 0,
        7, 0, 0, 3, 0, 0, 0, 8, 6,
        0, 0, 4, 0, 7, 0, 0, 0, 0,
        6, 0, 0, 1, 0, 9, 0, 0, 2,
        0, 0, 0, 0, 6, 0, 9, 0, 0,
        3, 5, 0, 0, 0, 7, 0, 0, 8,
        0, 6, 0, 0, 0, 1, 4, 2, 0,
        4, 0, 0, 6, 0, 0, 5, 0, 0
    };
}