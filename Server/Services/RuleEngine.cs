using rsp_game.Models;

namespace rsp_game.Services;

public class RuleEngine
{
    private readonly Dictionary<string, string> _winningMoves;

    public RuleEngine()
    {
        // Define the rules of the game: Key move beats Value move
        _winningMoves = new Dictionary<string, string>
        {
            { Moves.Rock, Moves.Scissors },   // Rock beats Scissors
            { Moves.Scissors, Moves.Paper },  // Scissors beats Paper
            { Moves.Paper, Moves.Rock }       // Paper beats Rock
        };
    }

    public string DetermineWinner(string player1Move, string player2Move)
    {
        // If both players choose the same move, it's a draw
        if (player1Move == player2Move)
        {
            return "Game was a draw"; 
        }

        // Check if Player 1's move beats Player 2's move
        if (_winningMoves[player1Move] == player2Move)
        {
            return "Player 1 wins";
        }

        // Otherwise, Player 2 wins
        return "Player 2 wins";
    }
}