import IGameGroupDTO from "../game-group/IGameGroupDTO";

export default interface ICompetitionStageDTO {
    id: string;
    name: string;
    scoringRulesName: string;
    gameGroups: IGameGroupDTO[];
}
