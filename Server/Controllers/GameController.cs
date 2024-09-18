using Microsoft.AspNetCore.Mvc;
using rsp_game.Dto;
using rsp_game.Mapper;
using rsp_game.Services;

namespace rsp_game.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly GameService _gameService;

    public GameController(GameService gameService)
    {
        _gameService = gameService;
    }

    [HttpPost]
    [Route("create")]
    public IActionResult CreateGame([FromBody] CreatePlayerDto player)
    {
        var game = _gameService.CreateGame(player.Name);
        return Ok(GameMapper.ToDto(game));
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetGame(Guid id)
    {
        var game = _gameService.GetGame(id);
        if (game != null)
        {
            return Ok(GameMapper.ToDto(game));
        }

        return NotFound(new { Message = "Game not found" });
    }

    [HttpPut]
    [Route("{id}/join")]
    public IActionResult JoinGame(Guid id, [FromBody] CreatePlayerDto player)
    {
        var game = _gameService.JoinGame(id, player.Name);
        if (game != null)
        {
            return Ok(GameMapper.ToDto(game));
        }

        return NotFound(new { Message = "Game not found" });
    }

    [HttpPut]
    [Route("{id}/move")]
    public IActionResult ExecuteMove(Guid id, [FromBody] MakeMoveDto moveDto)
    {
        var game = _gameService.ExecuteMove(id, moveDto);
        if (game != null)
        {
            return Ok(GameMapper.ToDto(game));
        }

        return NotFound(new { Message = "Game not found" });
    }
}