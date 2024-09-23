using rsp_game.Models;
using System.ComponentModel.DataAnnotations;

namespace rsp_game.Dto;

public class MakeMoveDto
{
    [RegularExpression("Rock|Scissors|Paper", ErrorMessage = "Invalid move type. Must be 'Rock', 'Scissors', or 'Paper'.")]
    public string Move { get; set; } = string.Empty;
    public string PlayerId { get; set; } = string.Empty;
}