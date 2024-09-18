import { Button, Card, CardContent, CardHeader, Stack, styled, TextField, Typography } from "@mui/material";
import { GameState, Moves, UseGame, useGame } from "./game/useGame.ts";
import { Game, Move } from "./game/service/gameService.ts";

const Container = styled('div')`
    width: 100%;
    height: 100%;
    padding: 32px;
`;

type InitProps = Pick<UseGame, "onCreateGame" | "setGameId" | "onJoinGame"> & Pick<Game, "id">

const Init = ({ onCreateGame, id, setGameId, onJoinGame }: InitProps) =>
    <>
        <Button style={{ backgroundColor: "#11171d" }} onClick={onCreateGame} variant={"contained"}>Create
            Game</Button>

        <div style={{ display: "flex", justifyContent: "space-between" }}>
            <TextField style={{ flex: 1, marginRight: 32 }} label={"Enter game ID"} value={id}
                       onChange={(e) => setGameId(e.target.value)}/>
            <Button variant={"contained"} onClick={onJoinGame} style={{ backgroundColor: "#11171d" }}>Join Game</Button>
        </div>
    </>

type WaitingProps = Pick<Game, "id">;
const Waiting = ({ id }: WaitingProps) =>
    <>
        <Typography>Waiting for Player 2 to join...</Typography>
        <Typography fontWeight={"bold"}>GameId: {id}</Typography>
    </>

type PlayGameProps = Pick<UseGame, "onPlayMove"> & Pick<Game, "state">
const PlayGame = ({ onPlayMove, state }: PlayGameProps) => {
    let header = "Player 1's turn";

    if (state === GameState.Player2Move) {
        header = "Player 2's turn";
    }


    return <>
        <Typography variant={"h6"}>{header}</Typography>
        <Stack direction={"row"} spacing={2}>
            <Button variant={"contained"} onClick={() => onPlayMove(Move.Rock)}
                    style={{ backgroundColor: "#11171d" }}>{Moves.Rock}</Button>
            <Button variant={"contained"} onClick={() => onPlayMove(Move.Paper)}
                    style={{ backgroundColor: "#11171d" }}>{Moves.Paper}</Button>
            <Button variant={"contained"} onClick={() => onPlayMove(Move.Scissors)}
                    style={{ backgroundColor: "#11171d" }}>{Moves.Scissors}</Button>
        </Stack>
    </>;
}

type ResultProps = Pick<Game, "resultText" | "p1MoveText" | "p2MoveText">
const Result = ({ resultText, p1MoveText, p2MoveText }: ResultProps) => {

    return <Stack spacing={2}>
        <Typography variant={"h6"}>Result</Typography>
        <Typography>Player 1: {p1MoveText}</Typography>
        <Typography>Player 2: {p2MoveText}</Typography>
        <Typography fontWeight={"bold"}>{resultText}</Typography>
    </Stack>
}

function App() {
    const { onCreateGame, game, setGameId, onJoinGame, onPlayMove } = useGame();
    const { state, id, ...rest } = game;

    return (
        <Container>
            <Card>
                <CardHeader title={"Rock Paper Scissors"}/>
                <CardContent>
                    <Stack spacing={2}>
                        {state === GameState.Init &&
                            <Init onCreateGame={onCreateGame} setGameId={setGameId} id={id}
                                  onJoinGame={onJoinGame}/>}
                        {state === GameState.Waiting && <Waiting id={id}/>}
                        {(state === GameState.Player1Move || state === GameState.Player2Move) &&
                            <PlayGame onPlayMove={onPlayMove} state={state}/>}
                        {state === GameState.Result && <Result {...rest}/>}
                    </Stack>
                </CardContent>
            </Card>
        </Container>
    )
}

export default App
