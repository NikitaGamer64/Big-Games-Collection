using GamesCore.Interfaces;
using GamesCore.Models;

namespace Examples;

/// <summary>
/// Пример простой игры - угадай число
/// Демонстрирует базовое использование фреймворка
/// </summary>
public class GuessNumberGame : BaseGame
{
    private int _secretNumber;
    private bool _isInitialized;
    private bool _isRunning;

    public GuessNumberGame()
        : base(
            name: "Угадай число",
            description: "Классическая игра в угадывание числа от 1 до 100",
            minPlayers: 1,
            maxPlayers: 10)
    {
    }

    public override void Initialize()
    {
        if (_isInitialized)
            return;

        // Генерируем секретное число от 1 до 100
        var random = new Random();
        _secretNumber = random.Next(1, 101);
        _isInitialized = true;

        Console.WriteLine($"[{Name}] Игра инициализирована. Секретное число загадано!");
    }

    public override void Start()
    {
        if (!_isInitialized)
        {
            throw new InvalidOperationException("Игра не инициализирована!");
        }

        _isRunning = true;
        Console.WriteLine($"[{Name}] Игра началась! Попробуйте угадать число от 1 до 100.");
    }

    public override void Pause()
    {
        if (!_isRunning)
            return;

        _isRunning = false;
        Console.WriteLine($"[{Name}] Игра поставлена на паузу.");
    }

    public override void End()
    {
        _isRunning = false;
        Console.WriteLine($"[{Name}] Игра завершена. Секретное число было: {_secretNumber}");
    }

    /// <summary>
    /// Метод для проверки числа (специфичный для этой игры)
    /// </summary>
    public string CheckGuess(int guess)
    {
        if (!_isRunning)
        {
            return "Игра не запущена!";
        }

        if (guess == _secretNumber)
        {
            return "Верно! Вы угадали число!";
        }
        else if (guess < _secretNumber)
        {
            return "Слишком маленькое число. Попробуйте больше.";
        }
        else
        {
            return "Слишком большое число. Попробуйте меньше.";
        }
    }
}

/// <summary>
/// Пример использования игры в комнате с игроками
/// </summary>
public class GameRoomExample
{
    public static void DemonstrateGameRoom()
    {
        Console.WriteLine("=== Пример создания игровой комнаты ===\n");

        // 1. Создаём игру
        var game = new GuessNumberGame();
        Console.WriteLine($"Создана игра: {game.Name}");
        Console.WriteLine($"Описание: {game.Description}");
        Console.WriteLine($"Игроков: {game.MinPlayers}-{game.MaxPlayers}\n");

        // 2. Создаём комнату
        var room = new GameRoom("Комната для угадывания чисел", game, maxPlayers: 5);
        Console.WriteLine($"Создана комната: {room.RoomName}");
        Console.WriteLine($"ID комнаты: {room.RoomId}\n");

        // 3. Добавляем игроков
        var player1 = new Player("Алиса");
        var player2 = new Player("Боб");
        var player3 = new Player("Чарли");

        room.AddPlayer(player1); // Первый игрок становится организатором
        room.AddPlayer(player2);
        room.AddPlayer(player3);

        Console.WriteLine("Добавлены игроки:");
        foreach (var player in room.Players)
        {
            Console.WriteLine($"  - {player.Name} (Роль: {player.Role})");
        }
        Console.WriteLine();

        // 4. Работа с чатом
        Console.WriteLine("Сообщения в чате:");
        room.SendMessage(player1.PlayerId, "Всем привет! Готовы играть?");
        room.SendMessage(player2.PlayerId, "Да, давайте начнём!");
        room.SendMessage(player3.PlayerId, "Я готов!");

        foreach (var msg in room.GetChatHistory())
        {
            Console.WriteLine($"  [{msg.Timestamp:HH:mm:ss}] {msg.PlayerName}: {msg.Message}");
        }
        Console.WriteLine();

        // 5. Назначение ролей
        room.AssignRole(player2.PlayerId, PlayerRole.Moderator);
        Console.WriteLine($"{player2.Name} теперь {player2.Role}\n");

        // 6. Запуск игры
        Console.WriteLine("=== Начало игры ===");
        room.Status = RoomStatus.Ready;
        game.Initialize();
        game.Start();
        Console.WriteLine();

        // 7. Игровой процесс
        Console.WriteLine("Игроки делают попытки:");
        var guessNumberGame = game as GuessNumberGame;
        Console.WriteLine($"  {player1.Name}: " + guessNumberGame!.CheckGuess(50));
        Console.WriteLine($"  {player2.Name}: " + guessNumberGame.CheckGuess(75));
        Console.WriteLine($"  {player3.Name}: " + guessNumberGame.CheckGuess(63));
        Console.WriteLine();

        // 8. Завершение игры
        room.Status = RoomStatus.Finished;
        game.End();
        Console.WriteLine($"\nСтатус комнаты: {room.Status}");
    }
}

/// <summary>
/// Точка входа для демонстрации примера
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            GameRoomExample.DemonstrateGameRoom();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
