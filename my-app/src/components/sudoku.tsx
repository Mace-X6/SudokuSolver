import React, { useEffect, useState } from 'react';
import Confetti from 'react-confetti';

type PuzzleCell = {
    id: number;
    value: number;
    options: number[];
};
type Puzzle = PuzzleCell[];
type Difficulty = 'Easy' | 'Medium' | 'Hard' | 'Expert';

const SudokuPage: React.FC = () => {
    const [puzzle, setPuzzle] = useState<Puzzle | null>([]);
    const [isSolved, setIsSolved] = useState<boolean>(false);
    const [difficulty, setDifficulty] = useState<Difficulty>('Easy');

    const fetchPuzzle = async (endpoint: string) => {
        try {
          const response = await fetch(`Sudoku/${endpoint}?difficulty=${difficulty}`);
          const data = await response.json();
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
            gradualUpdate(data);
        } catch (error) {
            console.error('Error:', error);
        }
    };

    const gradualUpdate = async (data: any) => {
        const newCells = data.cells;
        // Create an array of indices and shuffle it
        const indices = Array.from({ length: newCells.length }, (_, i) => i);
        for (let i = indices.length - 1; i > 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
            [indices[i], indices[j]] = [indices[j], indices[i]];
        }
    
        // Update the cells in the order specified by the shuffled indices array
        for (const i of indices) {
            await new Promise(r => setTimeout(r, 50));
            setPuzzle(oldCells => [...(oldCells as Puzzle).slice(0, i), newCells[i], ...(oldCells as Puzzle).slice(i+1)]);
        }
        setIsSolved(data.isSolved);
    };

    useEffect(() => {
        fetchPuzzle('GetPuzzle');
    }, []);

    const handleDifficultyChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setDifficulty(event.target.value as Difficulty);
    };
    const handleSolve = () => {
        postPuzzle('SolvePuzzle');
    };

    const handleReset = () => {
        setIsSolved(false);
        fetchPuzzle('GetPuzzle');
    };

    return (
        <div>
          <h1>Sudoku Puzzle</h1>
          <div style={{ display: 'grid', border: '1px solid white', backgroundColor: 'white', gridTemplateColumns: 'repeat(9, 1fr)', gap: '2px' }}>
            {puzzle && puzzle.map((cell) => (
              <div key={cell.id} style={{ backgroundColor: 'black', padding: '1px' }}>
                {cell.value === 0 ? '' : cell.value}
              </div>
            ))}
             {isSolved && <Confetti />}
          </div>
          <div>
                <label>
                    <input type="radio" value="Easy" checked={difficulty === 'Easy'} onChange={handleDifficultyChange} />
                    Easy
                </label>
                <label>
                    <input type="radio" value="Medium" checked={difficulty === 'Medium'} onChange={handleDifficultyChange} />
                    Medium
                </label>
                <label>
                    <input type="radio" value="Hard" checked={difficulty === 'Hard'} onChange={handleDifficultyChange} />
                    Hard
                </label>
                <label>
                    <input type="radio" value="Expert" checked={difficulty === 'Expert'} onChange={handleDifficultyChange} />
                    Expert
                </label>
            </div>
          <button onClick={handleReset}>GET PUZZLE</button>
          <button onClick={handleSolve}>SOLVE</button>
        </div>
    );
};

export default SudokuPage;
