﻿namespace rsp_game.Models;

public class Player
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Move { get; set; } = Moves.None;
}