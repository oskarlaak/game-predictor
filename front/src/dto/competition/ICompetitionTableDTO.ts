import ICompetitionStageDTO from "../competition-stage/ICompetitionStageDTO";
import ICompetitionUserDTO from "../competition-user/ICompetitionUserDTO";

export default interface ICompetitionTableDTO {
    name: string;
    hasEnded: boolean;
    userIsHost: boolean;
    competitionUsers: ICompetitionUserDTO[];
    competitionStages: ICompetitionStageDTO[];
}
