namespace GamesCore.Interfaces;

/// <summary>
/// Базовый интерфейс для всех игр в коллекции
/// </summary>
public interface IGame
{
    /// <summary>
    /// Уникальный идентификатор игры
    /// </summary>
    Guid GameId { get; }

    /// <summary>
    /// Название игры
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Описание игры
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Минимальное количество игроков
    /// </summary>
    int MinPlayers { get; }

    /// <summary>
    /// Максимальное количество игроков
    /// </summary>
    int MaxPlayers { get; }

    /// <summary>
    /// Инициализация игры
    /// </summary>
    void Initialize();

    /// <summary>
    /// Начало игры
    /// </summary>
    void Start();

    /// <summary>
    /// Пауза игры
    /// </summary>
    void Pause();

    /// <summary>
    /// Завершение игры
    /// </summary>
    void End();
}
