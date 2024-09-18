using rsp_game.Models;

namespace rsp_game.Services;

public class RuleEngine
{
    private readonly Dictionary<Move, Move> _winningMoves;

    public RuleEngine()
    {
        // Define the rules of the game: Key move beats Value move
        _winningMoves = new Dictionary<Move, Move>
        {
            { Move.Rock, Move.Scissors },   // Rock beats Scissors
            { Move.Scissors, Move.Paper },  // Scissors beat Paper
            { Move.Paper, Move.Rock }       // Paper beats Rock
        };
    }

    public GameResult DetermineWinner(Move player1Move, Move player2Move)
    {
        // If both players choose the same move, it's a draw
        if (player1Move == player2Move)
        {
            return GameResult.Draw;
        }

        // Check if Player 1's move beats Player 2's move
        if (_winningMoves[player1Move] == player2Move)
        {
            return GameResult.Player1Wins;
        }

        // Otherwise, Player 2 wins
        return GameResult.Player2Wins;
    }
}