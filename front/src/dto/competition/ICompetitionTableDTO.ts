import ICompetitionStageDTO from "../competition-stage/ICompetitionStageDTO";
import ICompetitionUserDTO from "../competition-user/ICompetitionUserDTO";

export default interface ICompetitionTableDTO {
    competitionUsers: ICompetitionUserDTO[];
    competitionStages: ICompetitionStageDTO[];
}
