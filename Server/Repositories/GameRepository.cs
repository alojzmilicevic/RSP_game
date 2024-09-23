using rsp_game.Models;

namespace rsp_game.Repositories;


public interface IGameRepository
{
    Game Get(Guid id);
    void Save(Game game);
}

public class InMemoryGameRepository : IGameRepository
{
    private readonly Dictionary<Guid, Game> _games = [];

    public Game Get(Guid id) => _games.TryGetValue(id, out var game) ? game : null;
    public void Save(Game game) => _games[game.Id] = game;
}

