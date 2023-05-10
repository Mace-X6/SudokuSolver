var array = [
    5, 3, 4, 6, 7, 8, 9, 1, 2,
    6, 7, 2, 1, 9, 5, 3, 4, 8,
    1, 9, 8, 3, 4, 2, 0, 0, 7,
    8, 5, 9, 0, 6, 0, 0, 0, 3,
    4, 2, 6, 0, 5, 3, 7, 0, 1,
    7, 1, 3, 0, 0, 4, 8, 5, 6,
    9, 6, 1, 0, 3, 7, 2, 8, 4,
    2, 8, 7, 0, 1, 1, 6, 0, 5,
    3, 4, 5, 2, 8, 6, 1, 7, 9
]

function fillSudokuGrid(array) {
    for (let i = 0; i < array.length; i++) {
        const row = Math.floor(i / 9);
        const col = i % 9;
        const cell = document.getElementById(`cell-${row}-${col}`);
        cell.textContent = array[i] > 0 ? array[i] : "";
    }
}

// document.getElementById('refresh').addEventListener('click', () => {
//     fillSudokuGrid(fetchField())
// })
fillSudokuGrid(array)