import IErrorDTO from "../dto/IErrorDTO";
import ISuccessDTO from "../dto/ISuccessDTO";
import IJwtDTO from "../dto/identity/IJwtDTO";
import ILoginDTO from "../dto/identity/ILoginDTO";
import IRegisterDTO from "../dto/identity/IRegisterDTO";
import BaseAuthoredService from "./base/BaseAuthoredService";

export default class IdentityService extends BaseAuthoredService {
    constructor(setJwt: (jwt: IJwtDTO | null) => void) {
        super('identity/', setJwt);
    }

    async register(registerDto: IRegisterDTO): Promise<IJwtDTO | IErrorDTO | undefined> {
        return await this.unauthoredPost<IJwtDTO | IErrorDTO>("register", registerDto);
    }

    async login(loginDto: ILoginDTO): Promise<IJwtDTO | IErrorDTO | undefined> {
        return await this.unauthoredPost<IJwtDTO | IErrorDTO>("login", loginDto);
    }

    async logout(jwt: IJwtDTO): Promise<ISuccessDTO | IErrorDTO | undefined> {
        return await this.authoredPost<ISuccessDTO | IErrorDTO>(jwt, "logout", jwt);
    }
}
