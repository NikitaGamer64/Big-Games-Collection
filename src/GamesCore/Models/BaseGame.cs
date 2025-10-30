using GamesCore.Interfaces;

namespace GamesCore.Models;

/// <summary>
/// Базовая абстрактная реализация игры
/// </summary>
public abstract class BaseGame : IGame
{
    public Guid GameId { get; protected set; }
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int MinPlayers { get; protected set; }
    public int MaxPlayers { get; protected set; }

    protected BaseGame(string name, string description, int minPlayers, int maxPlayers)
    {
        GameId = Guid.NewGuid();
        Name = name;
        Description = description;
        MinPlayers = minPlayers;
        MaxPlayers = maxPlayers;
    }

    public abstract void Initialize();
    public abstract void Start();
    public abstract void Pause();
    public abstract void End();
}
