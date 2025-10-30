namespace GamesCore.Interfaces;

/// <summary>
/// Роли участников в игровой комнате
/// </summary>
public enum PlayerRole
{
    /// <summary>
    /// Обычный игрок
    /// </summary>
    Player,

    /// <summary>
    /// Модератор
    /// </summary>
    Moderator,

    /// <summary>
    /// Организатор/Создатель комнаты
    /// </summary>
    Organizer,

    /// <summary>
    /// Ведущий (для телевизионных игр)
    /// </summary>
    Host,

    /// <summary>
    /// Оператор (для телевизионных игр)
    /// </summary>
    Operator,

    /// <summary>
    /// Редактор (для телевизионных игр)
    /// </summary>
    Editor,

    /// <summary>
    /// Наблюдатель
    /// </summary>
    Spectator
}
