import ICreatedDTO from "../dto/ICreatedDTO";
import IErrorDTO from "../dto/IErrorDTO";
import ISuccessDTO from "../dto/ISuccessDTO";
import ICompetitionDTO from "../dto/competition/ICompetitionDTO";
import ICompetitionPatchDTO from "../dto/competition/ICompetitionPatchDTO";
import ICompetitionPostDTO from "../dto/competition/ICompetitionPostDTO";
import ICompetitionPreviewDTO from "../dto/competition/ICompetitionPreviewDTO";
import ICompetitionTableDTO from "../dto/competition/ICompetitionTableDTO";
import BaseAuthoredService from "./base/BaseAuthoredService";

export default class CompetitionService extends BaseAuthoredService {
    public constructor() {
        super("Competition/");
    }

    public async getAll(): Promise<ICompetitionDTO[] | IErrorDTO | undefined> {
        return await this.authoredGet<ICompetitionDTO[]>("GetAll");
    }

    public async getPreview(id: string): Promise<ICompetitionPreviewDTO | IErrorDTO | undefined> {
        return await this.authoredGet<ICompetitionPreviewDTO>("GetPreview/" + id);
    }

    public async getTable(id: string): Promise<ICompetitionTableDTO | IErrorDTO | undefined> {
        return await this.authoredGet<ICompetitionTableDTO>("GetTable/" + id);
    }

    public async post(dto: ICompetitionPostDTO): Promise<ICreatedDTO | IErrorDTO | undefined> {
        return await this.authoredPost<ICreatedDTO>("Post", dto);
    }

    public async join(id: string): Promise<ISuccessDTO | IErrorDTO | undefined> {
        return await this.authoredPost<ISuccessDTO>("Join/" + id);
    }

    public async patch(id: string, dto: ICompetitionPatchDTO): Promise<ISuccessDTO | IErrorDTO | undefined> {
        return await this.authoredPatch<ISuccessDTO>("Patch/" + id, dto);
    }

    public async delete(id: string): Promise<ISuccessDTO | IErrorDTO | undefined> {
        return await this.authoredDelete<ISuccessDTO>("Delete/" + id);
    }

    public async leave(id: string): Promise<ISuccessDTO | IErrorDTO | undefined> {
        return await this.authoredDelete<ISuccessDTO>("Leave/" + id);
    }
}
