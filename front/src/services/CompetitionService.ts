import IErrorDTO from "../dto/IErrorDTO";
import ICompetitionDTO from "../dto/competition/ICompetitionDTO";
import ICompetitionTableDTO from "../dto/competition/ICompetitionTableDTO";
import IJwtDTO from "../dto/identity/IJwtDTO";
import BaseAuthoredService from "./base/BaseAuthoredService";

export default class CompetitionService extends BaseAuthoredService {
    public constructor(setJwt: (jwt: IJwtDTO | null) => void) {
        super("competition/", setJwt);
    }

    public async getAll(jwt: IJwtDTO): Promise<ICompetitionDTO[] | undefined> {
        return await this.authoredGet<ICompetitionDTO[]>(jwt, "getall");
    }

    public async get(jwt: IJwtDTO, id: string): Promise<ICompetitionDTO | IErrorDTO | undefined> {
        return await this.authoredGet<ICompetitionDTO | IErrorDTO>(jwt, "get/" + id);
    }

    public async getTable(jwt: IJwtDTO, id: string): Promise<ICompetitionTableDTO | IErrorDTO | undefined> {
        return await this.authoredGet<ICompetitionTableDTO | IErrorDTO>(jwt, "gettable/" + id);
    }
}
