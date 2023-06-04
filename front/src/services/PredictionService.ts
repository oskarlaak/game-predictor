import IErrorDTO from "../dto/IErrorDTO";
import IPredictionDTO from "../dto/prediction/IPredictionDTO";
import IPredictionPostDTO from "../dto/prediction/IPredictionPostDTO";
import BaseAuthoredService from "./base/BaseAuthoredService";

export default class PredictionService extends BaseAuthoredService {
    protected constructor() {
        super("Prediction/");
    }

    public async getAllForGame(id: string): Promise<IPredictionDTO[] | IErrorDTO | undefined> {
        return await this.authoredGet<IPredictionDTO[]>("GetAllForGame/" + id);
    }

    public async post(dto: IPredictionPostDTO): Promise<IPredictionDTO[] | IErrorDTO | undefined> {
        return await this.authoredPost<IPredictionDTO[]>("Post", dto);
    }
}
