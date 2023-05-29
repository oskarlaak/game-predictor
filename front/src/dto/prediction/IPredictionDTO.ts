export default interface IPredictionDTO {
    competitionUserId: string;
    teamOneScore: number | null;
    teamTwoScore: number | null;
    points: number | null;
    isHidden: boolean;
}
