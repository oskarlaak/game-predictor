import { AxiosResponse, isAxiosError } from "axios";
import ICreatedDTO from "../../dto/ICreatedDTO";
import IErrorDTO from "../../dto/IErrorDTO";
import ISuccessDTO from "../../dto/ISuccessDTO";
import IJwtDTO from "../../dto/identity/IJwtDTO";
import BaseService from "./BaseService";
import IdentityService from "../IdentityService";

export default abstract class BaseAuthoredService extends BaseService {

    private readonly setJwt: (jwt: IJwtDTO | null) => void;

    constructor(
        url: string,
        setJwt: (jwt: IJwtDTO | null) => void
    ) {
        super(url);
        this.setJwt = setJwt;
    }

    protected async defaultAuthoredPost(jwt: IJwtDTO, postDto: any): Promise<ICreatedDTO | IErrorDTO | undefined> {
        return await this.authoredPost<ICreatedDTO | IErrorDTO>(jwt, "post", postDto);
    }

    protected async defaultAuthoredPut(jwt: IJwtDTO, id: string, putDto: any): Promise<ISuccessDTO | IErrorDTO | undefined> {
        return await this.authoredPut<ISuccessDTO | IErrorDTO>(jwt, "put/" + id, putDto);
    }

    protected async defaultAuthoredDelete(jwt: IJwtDTO, id: string): Promise<ISuccessDTO | IErrorDTO | undefined> {
        return await this.authoredDelete<ISuccessDTO | IErrorDTO>(jwt, "delete/" + id);
    }

    protected async authoredGet<T>(
        jwt: IJwtDTO,
        url: string,
        refreshJwtWhenUnauthorized: boolean = true
    ): Promise<T | undefined> {

        let response: AxiosResponse<T>;
        try{
            response = await this.axios.get<T>(
                url,
                {
                    headers: {
                        'Authorization': 'Bearer ' + jwt.token
                    }
                }
            );
        } catch (e) {
            if (isAxiosError(e) && e.response) {
                if (e.response.status === 401) {
                    if (refreshJwtWhenUnauthorized) {
                        let identityService = new IdentityService(this.setJwt);

                        let refreshResponse: IJwtDTO | IErrorDTO | undefined = await identityService.refreshJwt(jwt);

                        if (refreshResponse !== undefined && !("errorMessage" in refreshResponse)) {
                            this.setJwt(refreshResponse);

                            return await this.authoredGet<T>(refreshResponse, url, false);
                        }
                    }
                    return undefined
                } 
                return e.response.data;
            }
            return undefined;
        }
        return response.data;
    }

    protected async authoredPost<T>(
        jwt: IJwtDTO,
        url: string,
        data?: any,
        refreshJwtWhenUnauthorized: boolean = true
    ): Promise<T | undefined> {
    
        let response: AxiosResponse<T>;
        try{
            response = await this.axios.post<T>(
                url,
                data,
                {
                    headers: {
                        'Authorization': 'Bearer ' + jwt.token
                    }
                }
            );
        } catch (e) {
            if (isAxiosError(e) && e.response) {
                if (e.response.status === 401) {
                    if (refreshJwtWhenUnauthorized) {
                        let identityService = new IdentityService(this.setJwt);

                        let refreshResponse: IJwtDTO | IErrorDTO | undefined = await identityService.refreshJwt(jwt);

                        if (refreshResponse !== undefined && !("errorMessage" in refreshResponse)) {
                            this.setJwt(refreshResponse);

                            return await this.authoredPost<T>(refreshResponse, url, data, false);
                        }
                    }
                    return undefined
                } 
                return e.response.data;
            }
            return undefined;
        }
        return response.data;
    }

    protected async authoredPut<T>(
        jwt: IJwtDTO,
        url: string,
        data?: any,
        refreshJwtWhenUnauthorized: boolean = true
    ): Promise<T | undefined> {
    
        let response: AxiosResponse<T>;
        try{
            response = await this.axios.put<T>(
                url,
                data,
                {
                    headers: {
                        'Authorization': 'Bearer ' + jwt.token
                    }
                }
            );
        } catch (e) {
            if (isAxiosError(e) && e.response) {
                if (e.response.status === 401) {
                    if (refreshJwtWhenUnauthorized) {
                        let identityService = new IdentityService(this.setJwt);

                        let refreshResponse: IJwtDTO | IErrorDTO | undefined = await identityService.refreshJwt(jwt);

                        if (refreshResponse !== undefined && !("errorMessage" in refreshResponse)) {
                            this.setJwt(refreshResponse);

                            return await this.authoredPut<T>(refreshResponse, url, data, false);
                        }
                    }
                    return undefined
                } 
                return e.response.data;
            }
            return undefined;
        }
        return response.data;
    }

    protected async authoredDelete<T>(
        jwt: IJwtDTO,
        url: string,
        refreshJwtWhenUnauthorized: boolean = true
    ): Promise<T | undefined> {
    
        let response: AxiosResponse<T>;
        try{
            response = await this.axios.delete<T>(
                url,
                {
                    headers: {
                        'Authorization': 'Bearer ' + jwt.token
                    }
                }
            );
        } catch (e) {
            if (isAxiosError(e) && e.response) {
                if (e.response.status === 401) {
                    if (refreshJwtWhenUnauthorized) {
                        let identityService = new IdentityService(this.setJwt);

                        let refreshResponse: IJwtDTO | IErrorDTO | undefined = await identityService.refreshJwt(jwt);

                        if (refreshResponse !== undefined && !("errorMessage" in refreshResponse)) {
                            this.setJwt(refreshResponse);

                            return await this.authoredDelete<T>(refreshResponse, url, false);
                        }
                    }
                    return undefined
                } 
                return e.response.data;
            }
            return undefined;
        }
        return response.data;
    }
}
