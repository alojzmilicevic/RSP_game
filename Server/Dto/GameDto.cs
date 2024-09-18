using rsp_game.Models;

namespace rsp_game.Dto;

public class GameDto
{
    public string Id { get; set; } = string.Empty;
    public string? P1MoveText { get; set; }
    public Move? P1Move { get; set; }
    public string? P2MoveText { get; set; }
    public Move? P2Move { get; set; }
    public GameState State { get; set; }
    public string? ResultText { get; set; }
}