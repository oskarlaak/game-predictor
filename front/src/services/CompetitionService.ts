import IErrorDTO from "../dto/IErrorDTO";
import ICompetitionDTO from "../dto/competition/ICompetitionDTO";
import ICompetitionTableDTO from "../dto/competition/ICompetitionTableDTO";
import BaseAuthoredService from "./base/BaseAuthoredService";

export default class CompetitionService extends BaseAuthoredService {
    public constructor() {
        super("competition/");
    }

    public async getAll(): Promise<ICompetitionDTO[] | undefined> {
        return await this.authoredGet<ICompetitionDTO[]>("getall");
    }

    public async get(id: string): Promise<ICompetitionDTO | IErrorDTO | undefined> {
        return await this.authoredGet<ICompetitionDTO | IErrorDTO>("get/" + id);
    }

    public async getTable(id: string): Promise<ICompetitionTableDTO | IErrorDTO | undefined> {
        return await this.authoredGet<ICompetitionTableDTO | IErrorDTO>("gettable/" + id);
    }
}
