import React, { useEffect, useState } from 'react';

type PuzzleCell = {
    id: number;
    value: number;
    options: number[];
};
type Puzzle = PuzzleCell[];

const SudokuPage: React.FC = () => {
    const [puzzle, setPuzzle] = useState<Puzzle | null>([]);

    const fetchPuzzle = async (endpoint: string) => {
        try {
          const response = await fetch(`Sudoku/${endpoint}`);
          const data = await response.json();
          
         console.log(data)
          setPuzzle(data.cells);
        } catch (error) {
          console.error('Error:', error);
        }
    };

    const postPuzzle = async (endpoint: string) => {
        try {
            const response = await fetch(`Sudoku/${endpoint}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(puzzle?.map(x => x.value))
            });
            const data = await response.json();
            setPuzzle(data.cells);
        } catch (error) {
            console.error('Error:', error);
        }
    };

    useEffect(() => {
        fetchPuzzle('GetPuzzle');
    }, []);

    const handleSolve = () => {
        postPuzzle('SolvePuzzle');
    };

    const handleReset = () => {
        fetchPuzzle('GetPuzzle');
    };

    return (
        <div>
          <h1>Sudoku Puzzle</h1>
          <div style={{ display: 'grid', border: '1px solid white', backgroundColor: 'white', gridTemplateColumns: 'repeat(9, 1fr)', gap: '1px' }}>
            {puzzle && puzzle.sort((a, b) => a.id - b.id).map((cell) => (
              <div key={cell.id} style={{ backgroundColor: 'black', padding: '1px' }}>
                {cell.value === 0 ? '' : cell.value}
              </div>
            ))}
          </div>
          <button onClick={handleSolve}>SOLVE</button>
          <button onClick={handleReset}>RESET</button>
        </div>
      );
};

export default SudokuPage;
