namespace SudokuSolver
{
    public static class SudokuSolver
    {
        public static int[] SolveSudoku(int[] sudokuField, int tries)
        {
            for (int h = 0; h < tries; h++)
            {
                for (int i = 0; i < 81; i++)
                {
                    if (sudokuField[i] == 0)
                    {
                        int[] usedNumbers = FindUsedNumbersInRange(sudokuField, i);
                        if (usedNumbers.Length < 9)
                        {
                            sudokuField[i] = FindFirstMissingInt(usedNumbers);
                        }
                    }
                }
            }
            return sudokuField;
        }
        private static int[] FindUsedNumbersInRange(int[] sudokuField, int index)
        {
            List<int> usedNumbers = new List<int>();
            //searching backwards in the row
            for (int j = index--; j % 9 == 0; j--)
            {
                usedNumbers.Add(sudokuField[j]);
            }
            //searching forwards in the row
            for (int k = index++; k < 80; k++)
            {
                if (k % 9 == 0) { break; }
                else
                {
                    usedNumbers.Add(sudokuField[k]);
                }
            }
            //searching down the column 
            for (int l = index + 9; l < 80; l += 9)
            {
                usedNumbers.Add(sudokuField[l]);
            }
            //searching up the column 
            for (int l = index - 9; l > 0; l -= 9)
            {
                usedNumbers.Add(sudokuField[l]);
            }

            //searching the 3x3 square
            //deciding in which square the index is
            int[] blockIndex = { 0, 0 };
            blockIndex[0] = Convert.ToInt32(Math.Floor((index % 9) / 3f));
            blockIndex[1] = Convert.ToInt32(Math.Floor(index / 27f));

            for (int m = 0; m < 3; m++)
            {
                // the first 3 numbers in the block are offset by the blockindex[0] to the right, by the blockindex[1] down in increments of 3 and down by m up to 3 times for a total of 9 squares a block
                usedNumbers.Add(sudokuField[3 * blockIndex[0] + 9 * m * blockIndex[1]]);
                usedNumbers.Add(sudokuField[1 + 3 * blockIndex[0] + 9 * m * blockIndex[1]]);
                usedNumbers.Add(sudokuField[2 + 3 * blockIndex[0] + 9 * m * blockIndex[1]]);
            }

            usedNumbers.Sort();
            usedNumbers.Distinct();
            int[] output = usedNumbers.ToArray();

            return output;
        }

        private static int FindFirstMissingInt(int[] array)
        {
            for (int i = 1; i < 10; i++)
            {
                if (array.Contains<int>(i))
                {
                    return i;
                }
            }
            return 0;
        }
    }
}