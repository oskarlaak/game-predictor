import { AxiosResponse, isAxiosError } from "axios";
import IErrorDTO from "../../dto/IErrorDTO";
import IJwtDTO from "../../dto/user-auth/IJwtDTO";
import BaseService from "./BaseService";
import { setJwt, getJwt } from "../../jwtHelpers";

export default abstract class BaseAuthoredService extends BaseService {

    protected constructor(url: string) {
        super(url);
    }

    private async refreshJwt(): Promise<IJwtDTO | IErrorDTO | undefined> {
        return await this.unauthoredPost<IJwtDTO | IErrorDTO>(this.baseUrl + "UserAuth/RefreshJwt", getJwt());
    }

    protected async authoredGet<T>(
        url: string,
        refreshJwtWhenUnauthorized = true
    ): Promise<T | IErrorDTO | undefined> {

        let response: AxiosResponse<T>;
        try{
            response = await this.axios.get<T>(
                url,
                {
                    headers: {
                        "Authorization": "Bearer " + getJwt()?.token
                    }
                }
            );
        } catch (e) {
            if (isAxiosError(e) && e.response) {
                if (e.response.status === 401) {
                    if (refreshJwtWhenUnauthorized) {

                        const refreshResponse: IJwtDTO | IErrorDTO | undefined = await this.refreshJwt();

                        if (refreshResponse !== undefined && !("errorMessage" in refreshResponse)) {

                            setJwt(refreshResponse);
                            return await this.authoredGet<T>(url, false);
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
        url: string,
        data?: unknown,
        refreshJwtWhenUnauthorized = true
    ): Promise<T | IErrorDTO | undefined> {
    
        let response: AxiosResponse<T>;
        try{
            response = await this.axios.post<T>(
                url,
                data,
                {
                    headers: {
                        "Authorization": "Bearer " + getJwt()?.token
                    }
                }
            );
        } catch (e) {
            if (isAxiosError(e) && e.response) {
                if (e.response.status === 401) {
                    if (refreshJwtWhenUnauthorized) {

                        const refreshResponse: IJwtDTO | IErrorDTO | undefined = await this.refreshJwt();

                        if (refreshResponse !== undefined && !("errorMessage" in refreshResponse)) {

                            setJwt(refreshResponse);
                            return await this.authoredPost<T>(url, data, false);
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
        url: string,
        data?: unknown,
        refreshJwtWhenUnauthorized = true
    ): Promise<T | IErrorDTO | undefined> {
    
        let response: AxiosResponse<T>;
        try{
            response = await this.axios.patch<T>(
                url,
                data,
                {
                    headers: {
                        "Authorization": "Bearer " + getJwt()?.token
                    }
                }
            );
        } catch (e) {
            if (isAxiosError(e) && e.response) {
                if (e.response.status === 401) {
                    if (refreshJwtWhenUnauthorized) {

                        const refreshResponse: IJwtDTO | IErrorDTO | undefined = await this.refreshJwt();

                        if (refreshResponse !== undefined && !("errorMessage" in refreshResponse)) {

                            setJwt(refreshResponse);
                            return await this.authoredPatch<T>(url, data, false);
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
        url: string,
        refreshJwtWhenUnauthorized = true
    ): Promise<T | IErrorDTO | undefined> {
    
        let response: AxiosResponse<T>;
        try{
            response = await this.axios.delete<T>(
                url,
                {
                    headers: {
                        "Authorization": "Bearer " + getJwt()?.token
                    }
                }
            );
        } catch (e) {
            if (isAxiosError(e) && e.response) {
                if (e.response.status === 401) {
                    if (refreshJwtWhenUnauthorized) {

                        const refreshResponse: IJwtDTO | IErrorDTO | undefined = await this.refreshJwt();

                        if (refreshResponse !== undefined && !("errorMessage" in refreshResponse)) {

                            setJwt(refreshResponse);
                            return await this.authoredDelete<T>(url, false);
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
