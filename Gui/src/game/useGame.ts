import * as GameService from "./service/gameService.ts";
import { useState } from "react";
import { Game, Move } from "./service/gameService.ts";

export enum GameState {
    Init,
    Waiting,
    Player1Move,
    Player2Move,
    Result,
}

export enum Moves {
    Rock = "Rock",
    Paper = "Paper",
    Scissors = "Scissors",
}

export type UseGame = {
    onCreateGame: () => Promise<void>;
    setGameId: (s: string) => void;
    onJoinGame: () => Promise<void>;
    onPlayMove: (move: Move) => Promise<void>;
    game: Game;
}

const initialState: Game = {
    id: "",
    state: GameState.Init,
}

export function useGame(): UseGame {
    const [ game, setGame ] = useState<Game>(initialState);

    const onCreateGame = async () => {
        const game = await GameService.createGame();
        setGame(game);
    }

    const onJoinGame = async () => {
        const res = await GameService.joinGame(game.id);
        setGame(res);
    }

    const setGameId = (id: string) => {
        const modifiedGame = { ...game };
        modifiedGame.id = id;
        setGame(modifiedGame);
    }

    const onPlayMove = async (move: Move) => {
        let player = "id_player1";

        if (game.state === GameState.Player2Move) {
            player = "id_player2";
        }

        const res = await GameService.playMove(game.id, move, player);
        setGame(res);
    }

    return { onCreateGame, game, setGameId, onJoinGame, onPlayMove };
}