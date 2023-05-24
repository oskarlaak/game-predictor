import ICompetitionDTO from "../dto/competition/ICompetitionDTO";
import IJwtDTO from "../dto/identity/IJwtDTO";
import BaseAuthoredService from "./base/BaseAuthoredService";

export default class CompetitionService extends BaseAuthoredService {
    constructor(setJwt: (jwt: IJwtDTO | null) => void) {
        super('competition/', setJwt);
    }

    async getAll(jwt: IJwtDTO): Promise<ICompetitionDTO[] | undefined> {
        return await this.authoredGet<ICompetitionDTO[]>(jwt, "getall");
    }
}
