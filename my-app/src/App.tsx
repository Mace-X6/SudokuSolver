import React from 'react';
import logo from './logo.svg';
import './App.css';
import SudokuPage from './components/sudoku';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <SudokuPage />
      </header>
    </div>
  );
}

export default App;
