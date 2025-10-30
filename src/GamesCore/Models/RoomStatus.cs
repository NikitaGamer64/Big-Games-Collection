namespace GamesCore.Interfaces;

/// <summary>
/// Статус игровой комнаты
/// </summary>
public enum RoomStatus
{
    /// <summary>
    /// Ожидание игроков
    /// </summary>
    WaitingForPlayers,

    /// <summary>
    /// Готова к запуску
    /// </summary>
    Ready,

    /// <summary>
    /// Игра идёт
    /// </summary>
    InProgress,

    /// <summary>
    /// Игра на паузе
    /// </summary>
    Paused,

    /// <summary>
    /// Игра завершена
    /// </summary>
    Finished,

    /// <summary>
    /// Комната закрыта
    /// </summary>
    Closed
}
