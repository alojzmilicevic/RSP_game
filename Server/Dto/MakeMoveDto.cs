using rsp_game.Models;

namespace rsp_game.Dto;

public class MakeMoveDto
{
    public Move Move { get; set; }
    public string PlayerId { get; set; } = string.Empty;
}