namespace GamesCore.Interfaces;

/// <summary>
/// Интерфейс игрока
/// </summary>
public interface IPlayer
{
    /// <summary>
    /// Уникальный идентификатор игрока
    /// </summary>
    Guid PlayerId { get; }

    /// <summary>
    /// Имя игрока
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// Роль игрока в комнате
    /// </summary>
    PlayerRole Role { get; set; }

    /// <summary>
    /// Статус подключения
    /// </summary>
    bool IsConnected { get; set; }
}
