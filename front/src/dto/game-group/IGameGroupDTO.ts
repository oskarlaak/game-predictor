import IGameDTO from "../game/IGameDTO";

export default interface IGameGroupDTO {
    id: string;
    name: string;
    games: IGameDTO[];
}
