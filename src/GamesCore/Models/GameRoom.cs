using GamesCore.Interfaces;

namespace GamesCore.Models;

/// <summary>
/// Реализация игровой комнаты
/// </summary>
public class GameRoom : IGameRoom
{
    public Guid RoomId { get; private set; }
    public string RoomName { get; set; }
    public IGame Game { get; private set; }
    public List<IPlayer> Players { get; private set; }
    public int MaxPlayers { get; private set; }
    public RoomStatus Status { get; set; }

    private readonly List<ChatMessage> _chatHistory;

    public GameRoom(string roomName, IGame game, int maxPlayers)
    {
        RoomId = Guid.NewGuid();
        RoomName = roomName;
        Game = game;
        MaxPlayers = maxPlayers;
        Players = new List<IPlayer>();
        Status = RoomStatus.WaitingForPlayers;
        _chatHistory = new List<ChatMessage>();
    }

    public bool AddPlayer(IPlayer player)
    {
        if (Players.Count >= MaxPlayers)
        {
            return false;
        }

        if (Players.Any(p => p.PlayerId == player.PlayerId))
        {
            return false;
        }

        Players.Add(player);

        // Первый игрок становится организатором
        if (Players.Count == 1)
        {
            player.Role = PlayerRole.Organizer;
        }

        return true;
    }

    public bool RemovePlayer(Guid playerId)
    {
        var player = Players.FirstOrDefault(p => p.PlayerId == playerId);
        if (player == null)
        {
            return false;
        }

        Players.Remove(player);

        // Если удалён организатор и есть другие игроки, назначить нового
        if (player.Role == PlayerRole.Organizer && Players.Count > 0)
        {
            Players[0].Role = PlayerRole.Organizer;
        }

        return true;
    }

    public void SendMessage(Guid playerId, string message)
    {
        var player = Players.FirstOrDefault(p => p.PlayerId == playerId);
        if (player != null)
        {
            var chatMessage = new ChatMessage
            {
                PlayerId = playerId,
                PlayerName = player.Name,
                Message = message,
                Timestamp = DateTime.UtcNow
            };
            _chatHistory.Add(chatMessage);
        }
    }

    public void AssignRole(Guid playerId, PlayerRole role)
    {
        var player = Players.FirstOrDefault(p => p.PlayerId == playerId);
        if (player != null)
        {
            player.Role = role;
        }
    }

    public IReadOnlyList<ChatMessage> GetChatHistory()
    {
        return _chatHistory.AsReadOnly();
    }
}

/// <summary>
/// Сообщение в чате
/// </summary>
public class ChatMessage
{
    public Guid PlayerId { get; set; }
    public string PlayerName { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
}
