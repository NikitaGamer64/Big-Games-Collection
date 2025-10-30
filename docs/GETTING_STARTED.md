# Начало работы с проектом

## Требования

- **Visual Studio 2022** или новее (с поддержкой .NET 8.0)
- **.NET 8.0 SDK** или новее
- **Windows 10/11** (для запуска WPF приложения)

## Установка и запуск

### 1. Клонирование репозитория

```bash
git clone https://github.com/NikitaGamer64/Blank.git
cd Blank
```

### 2. Открытие в Visual Studio

1. Откройте файл `GamesCollection.sln` в Visual Studio
2. Дождитесь загрузки всех зависимостей

### 3. Сборка проекта

```bash
dotnet build
```

Или в Visual Studio: `Build → Build Solution` (Ctrl+Shift+B)

### 4. Запуск приложения

```bash
dotnet run --project src/GamesHub/GamesHub.csproj
```

Или в Visual Studio: нажмите F5 для запуска с отладкой

## Структура решения

Проект состоит из двух основных компонентов:

1. **GamesCore** - Библиотека с общей логикой
   - Интерфейсы для игр, игроков и комнат
   - Базовые реализации
   - Модели данных

2. **GamesHub** - WPF приложение
   - Графический интерфейс
   - Главный лаунчер

## Разработка новой игры

### Шаг 1: Создайте класс игры

```csharp
using GamesCore.Models;

namespace YourNamespace;

public class YourGame : BaseGame
{
    public YourGame()
        : base("Название игры", "Описание", minPlayers: 2, maxPlayers: 4)
    {
    }

    public override void Initialize()
    {
        // Инициализация игры
    }

    public override void Start()
    {
        // Запуск игры
    }

    public override void Pause()
    {
        // Постановка на паузу
    }

    public override void End()
    {
        // Завершение игры
    }
}
```

### Шаг 2: Создайте комнату для игры

```csharp
using GamesCore.Models;

var game = new YourGame();
var room = new GameRoom("Название комнаты", game, maxPlayers: 4);

// Добавление игроков
var player1 = new Player("Игрок 1");
room.AddPlayer(player1);

// Назначение ролей
room.AssignRole(player1.PlayerId, PlayerRole.Organizer);

// Отправка сообщения в чат
room.SendMessage(player1.PlayerId, "Привет всем!");
```

## Тестирование

### Юнит-тесты (Планируется)

```bash
dotnet test
```

### Ручное тестирование

1. Запустите приложение GamesHub
2. Перейдите на вкладку "Комнаты"
3. Создайте новую комнату (функция будет добавлена)

## Следующие шаги

1. Изучите [архитектуру проекта](ARCHITECTURE.md)
2. Посмотрите примеры в папке `examples/`
3. Попробуйте создать свою первую игру

## Полезные команды

```bash
# Сборка проекта
dotnet build

# Запуск приложения
dotnet run --project src/GamesHub/GamesHub.csproj

# Очистка сборки
dotnet clean

# Восстановление зависимостей
dotnet restore
```

## Поддержка

Если у вас возникли вопросы или проблемы:
1. Проверьте [архитектуру проекта](ARCHITECTURE.md)
2. Создайте Issue в GitHub репозитории
