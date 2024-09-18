using rsp_game.Services;

namespace rsp_game.Models;

public class Game(RuleEngine ruleEngine, Player playerOne)
{
    private readonly RuleEngine _ruleEngine = ruleEngine;

    // Possible improvements would be storing all the moves in a list for backtracking and history.
    public Guid Id { get; set; } = Guid.NewGuid();
    public Player PlayerOne { get; set; } = playerOne;
    public Move? P1Move { get; set; }
    public Player? PlayerTwo { get; set; }
    public Move? P2Move { get; set; }
    public GameState State { get; set; } = GameState.Waiting;
    public GameResult? Result { get; set; }

    // Would rather have this as part of the domain layer, but keeping it simple here.
    public void MakeMove(string playerId, Move move)
    {
        // Domain logic for making a move
        if (State == GameState.Player1Move && playerId == PlayerOne.Id)
        {
            P1Move = move;
            State = GameState.Player2Move;
        }
        else if (State == GameState.Player2Move && playerId == PlayerTwo?.Id)
        {
            P2Move = move;
            Result = _ruleEngine.DetermineWinner(P1Move.Value, P2Move.Value);
            State = GameState.Result;
        }
        else
        {
            throw new InvalidOperationException("Invalid move or player.");
        }
    }
}
