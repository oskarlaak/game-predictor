export default interface ICompetitionDTO {
    id: string;
    name: string;
    type: string;
    hasEnded: boolean;
    userIsHost: boolean;
    actionCount: number;
}
