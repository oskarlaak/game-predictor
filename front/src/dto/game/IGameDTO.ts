import IPredictionDTO from "../prediction/IPredictionDTO";

export default interface IGameDTO {
    id: string;
    teamOneName: string;
    teamTwoName: string;
    teamOneScore: number | null;
    teamTwoScore: number | null;
    predictionDeadlineDT: string;
    predictions: IPredictionDTO[];
}
