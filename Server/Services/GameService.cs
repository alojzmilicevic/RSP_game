using rsp_game.Dto;
using rsp_game.Models;
using rsp_game.Repositories;

namespace rsp_game.Services;

public class GameService
{
    private readonly IGameRepository _gameRepository;
    private readonly RuleEngine _ruleEngine;

    public GameService(IGameRepository gameRepository, RuleEngine ruleEngine)
    {
        _gameRepository = gameRepository;
        _ruleEngine = ruleEngine;
    }

    public Game CreateGame(string name)
    {
        var playerOne = new Player
        {
            Id = "id_player1", // Simulating a generated ID, could be replaced with a real ID generation logic
            Name = name
        };

        var game = new Game(_ruleEngine, playerOne);

        _gameRepository.Save(game);

        return game;
    }

    public Game? GetGame(Guid id)
    {
        return _gameRepository.Get(id);
    }

    public Game? JoinGame(Guid id, string name)
    {
        var game = _gameRepository.Get(id);

        if (game == null)
        {
            return null;
        }

        game.PlayerTwo = new Player
        {
            Id = "id_player2", // Simulating another player ID
            Name = name
        };
        game.State = GameState.Player1Move;

        _gameRepository.Save(game);

        return game;
    }

    public Game? ExecuteMove(Guid id, MakeMoveDto moveDto)
    {
        var game = _gameRepository.Get(id);

        if (game == null)
        {
            return null;
        }

        game.MakeMove(moveDto.PlayerId, moveDto.Move);

        _gameRepository.Save(game);

        return game;
    }
}
