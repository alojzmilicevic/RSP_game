import axios from "axios";
import { GameState, Moves } from "../useGame.ts";

export enum Move {
    Rock,
    Paper,
    Scissors,
}

export type Game = {
    id: string;
    p1MoveText?: Moves,
    p1Move?: Move,
    p2Move?: Move,
    p2MoveText?: Moves,
    state?: GameState;
    resultText?: string;
}

const baseUrl = "http://localhost:5133/api/Game"

export const createGame = async (): Promise<Game> =>
    await axios.post(`${baseUrl}/create`, {
        name: "Player 1",
    }).then((res) => res.data);

export const joinGame = (id: string): Promise<Game> =>
    axios.put(`${baseUrl}/${id}/join`, {
        name: "Player 2",
    }).then((res) => res.data);

export const playMove = async (id: string, move: Move, playerId: string): Promise<Game> =>
    await axios.put(`${baseUrl}/${id}/move`, {
        move,
        playerId
    }).then(res => res.data);

export const getGame = async (id: string): Promise<Game> =>
    await axios.get(`${baseUrl}/${id}`).then(res => res.data);

