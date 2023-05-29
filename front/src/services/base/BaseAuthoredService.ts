import { AxiosResponse, isAxiosError } from "axios";
import ICreatedDTO from "../../dto/ICreatedDTO";
import IErrorDTO from "../../dto/IErrorDTO";
import ISuccessDTO from "../../dto/ISuccessDTO";
import IJwtDTO from "../../dto/identity/IJwtDTO";
import BaseService from "./BaseService";

export default abstract class BaseAuthoredService extends BaseService {

    private readonly setJwt: (jwt: IJwtDTO | null) => void;

    protected constructor(
        url: string,
        setJwt: (jwt: IJwtDTO | null) => void
    ) {
        super(url);
        this.setJwt = setJwt;
    }

    protected async defaultAuthoredPost(jwt: IJwtDTO, postDto: any): Promise<ICreatedDTO | IErrorDTO | undefined> {
        return await this.authoredPost<ICreatedDTO | IErrorDTO>(jwt, "post", postDto);
    }

    protected async defaultAuthoredPatch(jwt: IJwtDTO, id: string, putDto: any): Promise<ISuccessDTO | IErrorDTO | undefined> {
        return await this.authoredPatch<ISuccessDTO | IErrorDTO>(jwt, "patch/" + id, putDto);
    }

    protected async defaultAuthoredDelete(jwt: IJwtDTO, id: string): Promise<ISuccessDTO | IErrorDTO | undefined> {
        return await this.authoredDelete<ISuccessDTO | IErrorDTO>(jwt, "delete/" + id);
    }

    private async refreshJwt(jwt: IJwtDTO): Promise<IJwtDTO | IErrorDTO | undefined> {
        return await this.unauthoredPost<IJwtDTO | IErrorDTO>(this.baseUrl + "identity/refreshjwt", jwt);
    }

    protected async authoredGet<T>(
        jwt: IJwtDTO,
        url: string,
        refreshJwtWhenUnauthorized = true
    ): Promise<T | undefined> {

        let response: AxiosResponse<T>;
        try{
            response = await this.axios.get<T>(
                url,
                {
                    headers: {
                        "Authorization": "Bearer " + jwt.token
                    }
                }
            );
        } catch (e) {
            if (isAxiosError(e) && e.response) {
                if (e.response.status === 401) {
                    if (refreshJwtWhenUnauthorized) {

                        const refreshResponse: IJwtDTO | IErrorDTO | undefined = await this.refreshJwt(jwt);

                        if (refreshResponse !== undefined && !("errorMessage" in refreshResponse)) {
                            this.setJwt(refreshResponse);

                            return await this.authoredGet<T>(refreshResponse, url, false);
                        }
                    }
                    return undefined;
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
        refreshJwtWhenUnauthorized = true
    ): Promise<T | undefined> {
    
        let response: AxiosResponse<T>;
        try{
            response = await this.axios.post<T>(
                url,
                data,
                {
                    headers: {
                        "Authorization": "Bearer " + jwt.token
                    }
                }
            );
        } catch (e) {
            if (isAxiosError(e) && e.response) {
                if (e.response.status === 401) {
                    if (refreshJwtWhenUnauthorized) {

                        const refreshResponse: IJwtDTO | IErrorDTO | undefined = await this.refreshJwt(jwt);

                        if (refreshResponse !== undefined && !("errorMessage" in refreshResponse)) {
                            this.setJwt(refreshResponse);

                            return await this.authoredPost<T>(refreshResponse, url, data, false);
                        }
                    }
                    return undefined;
                } 
                return e.response.data;
            }
            return undefined;
        }
        return response.data;
    }

    protected async authoredPatch<T>(
        jwt: IJwtDTO,
        url: string,
        data?: any,
        refreshJwtWhenUnauthorized = true
    ): Promise<T | undefined> {
    
        let response: AxiosResponse<T>;
        try{
            response = await this.axios.patch<T>(
                url,
                data,
                {
                    headers: {
                        "Authorization": "Bearer " + jwt.token
                    }
                }
            );
        } catch (e) {
            if (isAxiosError(e) && e.response) {
                if (e.response.status === 401) {
                    if (refreshJwtWhenUnauthorized) {

                        const refreshResponse: IJwtDTO | IErrorDTO | undefined = await this.refreshJwt(jwt);

                        if (refreshResponse !== undefined && !("errorMessage" in refreshResponse)) {
                            this.setJwt(refreshResponse);

                            return await this.authoredPatch<T>(refreshResponse, url, data, false);
                        }
                    }
                    return undefined;
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
        refreshJwtWhenUnauthorized = true
    ): Promise<T | undefined> {
    
        let response: AxiosResponse<T>;
        try{
            response = await this.axios.delete<T>(
                url,
                {
                    headers: {
                        "Authorization": "Bearer " + jwt.token
                    }
                }
            );
        } catch (e) {
            if (isAxiosError(e) && e.response) {
                if (e.response.status === 401) {
                    if (refreshJwtWhenUnauthorized) {

                        const refreshResponse: IJwtDTO | IErrorDTO | undefined = await this.refreshJwt(jwt);

                        if (refreshResponse !== undefined && !("errorMessage" in refreshResponse)) {
                            this.setJwt(refreshResponse);

                            return await this.authoredDelete<T>(refreshResponse, url, false);
                        }
                    }
                    return undefined;
                } 
                return e.response.data;
            }
            return undefined;
        }
        return response.data;
    }
}
