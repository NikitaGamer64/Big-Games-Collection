using System;

namespace GamesCollection.TicTacToe
{
    /// <summary>
    /// Простая игра "Крестики-нолики" для двух игроков
    /// </summary>
    public class TicTacToe
    {
        private char[,] board;
        private char currentPlayer;
        private bool gameOver;
        private char winner;

        public TicTacToe()
        {
            board = new char[3, 3];
            currentPlayer = 'X';
            gameOver = false;
            winner = ' ';
            InitializeBoard();
        }

        /// <summary>
        /// Инициализация игрового поля
        /// </summary>
        private void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        /// <summary>
        /// Отображение текущего состояния доски
        /// </summary>
        public void DisplayBoard()
        {
            Console.WriteLine("\n  0   1   2");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{i} ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j]);
                    if (j < 2) Console.Write(" | ");
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine("  -----------");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Попытка сделать ход
        /// </summary>
        /// <param name="row">Строка (0-2)</param>
        /// <param name="col">Столбец (0-2)</param>
        /// <returns>true если ход успешен, false если клетка занята или координаты неверные</returns>
        public bool MakeMove(int row, int col)
        {
            if (gameOver)
            {
                Console.WriteLine("Игра уже завершена!");
                return false;
            }

            if (row < 0 || row > 2 || col < 0 || col > 2)
            {
                Console.WriteLine("Неверные координаты! Используйте числа от 0 до 2.");
                return false;
            }

            if (board[row, col] != ' ')
            {
                Console.WriteLine("Эта клетка уже занята!");
                return false;
            }

            board[row, col] = currentPlayer;

            if (CheckWin())
            {
                gameOver = true;
                winner = currentPlayer;
                return true;
            }

            if (CheckDraw())
            {
                gameOver = true;
                winner = 'D'; // Draw
                return true;
            }

            // Переключение игрока
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            return true;
        }

        /// <summary>
        /// Проверка победы
        /// </summary>
        private bool CheckWin()
        {
            // Проверка строк
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == currentPlayer &&
                    board[i, 1] == currentPlayer &&
                    board[i, 2] == currentPlayer)
                    return true;
            }

            // Проверка столбцов
            for (int j = 0; j < 3; j++)
            {
                if (board[0, j] == currentPlayer &&
                    board[1, j] == currentPlayer &&
                    board[2, j] == currentPlayer)
                    return true;
            }

            // Проверка диагоналей
            if (board[0, 0] == currentPlayer &&
                board[1, 1] == currentPlayer &&
                board[2, 2] == currentPlayer)
                return true;

            if (board[0, 2] == currentPlayer &&
                board[1, 1] == currentPlayer &&
                board[2, 0] == currentPlayer)
                return true;

            return false;
        }

        /// <summary>
        /// Проверка ничьи
        /// </summary>
        private bool CheckDraw()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Получить текущего игрока
        /// </summary>
        public char GetCurrentPlayer()
        {
            return currentPlayer;
        }

        /// <summary>
        /// Проверить, закончена ли игра
        /// </summary>
        public bool IsGameOver()
        {
            return gameOver;
        }

        /// <summary>
        /// Получить победителя (X, O, или D для ничьи)
        /// </summary>
        public char GetWinner()
        {
            return winner;
        }

        /// <summary>
        /// Запуск игры с консольным интерфейсом
        /// </summary>
        public void Play()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("  Добро пожаловать в Крестики-Нолики!");
            Console.WriteLine("=================================");
            Console.WriteLine("\nИгрок X начинает первым.");
            Console.WriteLine("Введите координаты хода (строка, столбец).");
            Console.WriteLine("Например: 0 0 для левого верхнего угла\n");

            while (!gameOver)
            {
                DisplayBoard();
                Console.WriteLine($"Ход игрока {currentPlayer}");
                Console.Write("Введите координаты (строка столбец): ");

                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Неверный ввод!");
                    continue;
                }

                string[] parts = input.Trim().Split(' ');
                if (parts.Length != 2)
                {
                    Console.WriteLine("Неверный формат! Введите два числа через пробел.");
                    continue;
                }

                if (int.TryParse(parts[0], out int row) && int.TryParse(parts[1], out int col))
                {
                    MakeMove(row, col);
                }
                else
                {
                    Console.WriteLine("Неверный формат! Используйте числа.");
                }
            }

            DisplayBoard();

            if (winner == 'D')
            {
                Console.WriteLine("Ничья! Игра завершена.");
            }
            else
            {
                Console.WriteLine($"Игрок {winner} победил! Поздравляем!");
            }
        }
    }

    /// <summary>
    /// Точка входа в программу
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var game = new TicTacToe();
                game.Play();

                Console.WriteLine("\nХотите сыграть ещё раз? (да/нет): ");
                string? response = Console.ReadLine();

                if (response == null || !response.Trim().ToLower().StartsWith("д"))
                {
                    Console.WriteLine("Спасибо за игру! До свидания!");
                    break;
                }

                Console.Clear();
            }
        }
    }
}
