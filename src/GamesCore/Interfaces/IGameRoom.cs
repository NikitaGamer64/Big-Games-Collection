namespace GamesCore.Interfaces;

/// <summary>
/// Интерфейс игровой комнаты с мультиплеером
/// </summary>
public interface IGameRoom
{
    /// <summary>
    /// Уникальный идентификатор комнаты
    /// </summary>
    Guid RoomId { get; }

    /// <summary>
    /// Название комнаты
    /// </summary>
    string RoomName { get; set; }

    /// <summary>
    /// Игра в комнате
    /// </summary>
    IGame Game { get; }

    /// <summary>
    /// Список игроков в комнате
    /// </summary>
    List<IPlayer> Players { get; }

    /// <summary>
    /// Максимальное количество игроков в комнате
    /// </summary>
    int MaxPlayers { get; }

    /// <summary>
    /// Статус комнаты
    /// </summary>
    RoomStatus Status { get; set; }

    /// <summary>
    /// Добавить игрока в комнату
    /// </summary>
    bool AddPlayer(IPlayer player);

    /// <summary>
    /// Удалить игрока из комнаты
    /// </summary>
    bool RemovePlayer(Guid playerId);

    /// <summary>
    /// Отправить сообщение в чат
    /// </summary>
    void SendMessage(Guid playerId, string message);

    /// <summary>
    /// Назначить роль игроку
    /// </summary>
    void AssignRole(Guid playerId, PlayerRole role);
}
