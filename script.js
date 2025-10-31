// Игровое состояние
let board = ['', '', '', '', '', '', '', '', ''];
let currentPlayer = 'X';
let gameActive = true;
let lastMoveIndex = -1;

// Выигрышные комбинации
const winningConditions = [
    [0, 1, 2], // верхняя горизонталь
    [3, 4, 5], // средняя горизонталь
    [6, 7, 8], // нижняя горизонталь
    [0, 3, 6], // левая вертикаль
    [1, 4, 7], // средняя вертикаль
    [2, 5, 8], // правая вертикаль
    [0, 4, 8], // диагональ сверху-слева вниз-вправо
    [2, 4, 6]  // диагональ сверху-справа вниз-влево
];

// DOM элементы
const cells = document.querySelectorAll('.cell');
const gameStatus = document.getElementById('game-status');
const resetButton = document.getElementById('reset-button');
const currentPlayerDisplay = document.getElementById('current-player');
const playerXDiv = document.querySelector('.player-x');
const playerODiv = document.querySelector('.player-o');

// Инициализация
init();

function init() {
    cells.forEach(cell => {
        cell.addEventListener('click', handleCellClick);
        cell.addEventListener('mouseenter', handleCellHover);
        cell.addEventListener('mouseleave', handleCellLeave);
    });

    resetButton.addEventListener('click', resetGame);
    updatePlayerIndicator();
}

// Обработка наведения на клетку (призрачный символ)
function handleCellHover(e) {
    const cell = e.target;
    const index = parseInt(cell.getAttribute('data-index'));

    if (board[index] === '' && gameActive) {
        cell.setAttribute('data-ghost', currentPlayer);
    }
}

function handleCellLeave(e) {
    const cell = e.target;
    cell.removeAttribute('data-ghost');
}

// Обработка клика на клетку
function handleCellClick(e) {
    const cell = e.target;
    const index = parseInt(cell.getAttribute('data-index'));

    // Проверка, можно ли сделать ход
    if (board[index] !== '' || !gameActive) {
        return;
    }

    // Делаем ход
    makeMove(cell, index);
}

function makeMove(cell, index) {
    // Обновляем состояние
    board[index] = currentPlayer;
    cell.textContent = currentPlayer;
    cell.classList.add('taken');
    cell.classList.add(currentPlayer.toLowerCase());

    // Убираем подсветку с предыдущего хода
    if (lastMoveIndex !== -1) {
        cells[lastMoveIndex].classList.remove('last-move');
    }

    // Подсвечиваем текущий ход
    cell.classList.add('last-move');
    lastMoveIndex = index;

    // Проверяем результат
    checkResult();
}

function checkResult() {
    let roundWon = false;
    let winningCombination = null;

    // Проверяем выигрышные комбинации
    for (let i = 0; i < winningConditions.length; i++) {
        const [a, b, c] = winningConditions[i];

        if (board[a] === '' || board[b] === '' || board[c] === '') {
            continue;
        }

        if (board[a] === board[b] && board[b] === board[c]) {
            roundWon = true;
            winningCombination = [a, b, c];
            break;
        }
    }

    if (roundWon) {
        handleWin(winningCombination);
        return;
    }

    // Проверяем ничью
    if (!board.includes('')) {
        handleDraw();
        return;
    }

    // Переходим к следующему игроку
    switchPlayer();
}

function handleWin(winningCombination) {
    gameActive = false;
    gameStatus.textContent = `Игрок ${currentPlayer} победил!`;
    gameStatus.classList.add('winner');

    // Подсвечиваем выигрышную комбинацию
    winningCombination.forEach(index => {
        cells[index].classList.add('winning');
    });
}

function handleDraw() {
    gameActive = false;
    gameStatus.textContent = 'Ничья!';
    gameStatus.classList.add('draw');
}

function switchPlayer() {
    currentPlayer = currentPlayer === 'X' ? 'O' : 'X';
    updatePlayerIndicator();
}

function updatePlayerIndicator() {
    currentPlayerDisplay.textContent = currentPlayer;

    if (currentPlayer === 'X') {
        playerXDiv.classList.add('active');
        playerODiv.classList.remove('active');
    } else {
        playerODiv.classList.add('active');
        playerXDiv.classList.remove('active');
    }
}

function resetGame() {
    // Сброс состояния
    board = ['', '', '', '', '', '', '', '', ''];
    currentPlayer = 'X';
    gameActive = true;
    lastMoveIndex = -1;

    // Очистка UI
    gameStatus.textContent = '';
    gameStatus.classList.remove('winner', 'draw');

    cells.forEach(cell => {
        cell.textContent = '';
        cell.classList.remove('taken', 'x', 'o', 'winning', 'last-move');
        cell.removeAttribute('data-ghost');
    });

    updatePlayerIndicator();
}
