namespace rsp_game.Mapper;

using Models;
using Dto;

public static class GameMapper
{
    public static GameDto ToDto(Game game)
    {
        var resultText = "";
        switch (game.Result)
        {
            case GameResult.Draw:
            {
                resultText = "Game was a draw";
                break;
            }
            case GameResult.Player1Wins:
                resultText = "Player 1 wins";
                break;
            case GameResult.Player2Wins:
                resultText = "Player 2 wins";
                break;
        }

        return new GameDto
        {
            Id = game.Id.ToString(),
            P1MoveText = game.P1Move?.ToString(),
            P2MoveText = game.P2Move?.ToString(),
            P1Move = game.P1Move,
            P2Move = game.P2Move,
            State = game.State,
            ResultText = resultText,
        };
    }
}
