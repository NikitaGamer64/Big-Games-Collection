using GamesCore.Interfaces;

namespace GamesCore.Models;

/// <summary>
/// Реализация игрока
/// </summary>
public class Player : IPlayer
{
    public Guid PlayerId { get; private set; }
    public string Name { get; set; }
    public PlayerRole Role { get; set; }
    public bool IsConnected { get; set; }

    public Player(string name)
    {
        PlayerId = Guid.NewGuid();
        Name = name;
        Role = PlayerRole.Player;
        IsConnected = true;
    }

    public Player(Guid playerId, string name, PlayerRole role = PlayerRole.Player)
    {
        PlayerId = playerId;
        Name = name;
        Role = role;
        IsConnected = true;
    }
}
