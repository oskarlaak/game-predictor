import IGameGroupDTO from "../game-group/IGameGroupDTO";

export default interface ICompetitionStageDTO {
    id: string;
    name: string;
    pointsOnCorrectScore: number;
    pointsOnCorrectScoreDifference: number;
    pointsOnCorrectResult: number;
    gameGroups: IGameGroupDTO[];
}
