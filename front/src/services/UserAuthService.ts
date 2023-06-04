import IErrorDTO from "../dto/IErrorDTO";
import ISuccessDTO from "../dto/ISuccessDTO";
import IJwtDTO from "../dto/user-auth/IJwtDTO";
import ILoginDTO from "../dto/user-auth/ILoginDTO";
import IRegisterDTO from "../dto/user-auth/IRegisterDTO";
import { getJwt } from "../jwtHelpers";
import BaseAuthoredService from "./base/BaseAuthoredService";

export default class UserAuthService extends BaseAuthoredService {
    public constructor() {
        super("UserAuth/");
    }

    public async register(registerDto: IRegisterDTO): Promise<IJwtDTO | IErrorDTO | undefined> {
        return await this.unauthoredPost<IJwtDTO>("Register", registerDto);
    }

    public async login(loginDto: ILoginDTO): Promise<IJwtDTO | IErrorDTO | undefined> {
        return await this.unauthoredPost<IJwtDTO>("Login", loginDto);
    }

    public async logout(): Promise<ISuccessDTO | IErrorDTO | undefined> {
        return await this.authoredPost<ISuccessDTO>("Logout", getJwt());
    }
}
