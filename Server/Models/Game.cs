using rsp_game.Services;

namespace rsp_game.Models;

public class Game(RuleEngine ruleEngine, Player playerOne)
{
    private readonly RuleEngine _ruleEngine = ruleEngine;

    // Possible improvements would be storing all the moves in a list for backtracking and history.
    public Guid Id { get; set; } = Guid.NewGuid();
    public Player PlayerOne { get; set; } = playerOne;
    public Player? PlayerTwo { get; set; }
    public GameState State { get; set; } = GameState.Waiting;
    public string? Result { get; set; }

    // Would rather have this as part of the domain layer, but keeping it simple here.
    public void MakeMove(string playerId, string move)
    {
        // Domain logic for making a move
        if (State == GameState.Player1Move && playerId == PlayerOne.Id)
        {
            PlayerOne.Move = move;
            State = GameState.Player2Move;
        }
        else if (State == GameState.Player2Move && playerId == PlayerTwo?.Id)
        {
            PlayerTwo.Move = move;
            Result = _ruleEngine.DetermineWinner(PlayerOne.Move, PlayerTwo.Move);
            State = GameState.Result;
        }
        else
        {
            throw new InvalidOperationException("Invalid move or player.");
        }
    }
}
