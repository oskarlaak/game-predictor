import Axios, { AxiosInstance, AxiosResponse, isAxiosError } from "axios";

export default abstract class BaseService {
    protected readonly axios: AxiosInstance;
    protected readonly baseUrl: string;

    protected constructor(url: string) {
        this.baseUrl = "https://localhost:7134/api/";

        this.axios = Axios.create({
            baseURL: this.baseUrl + url,
            headers: {
                common: {
                    "Content-Type": "application/json"
                }
            }
        });
    }

    protected async unauthoredGet<T>(url: string): Promise<T | undefined> {
        let response: AxiosResponse<T>;
        try {
            response = await this.axios.get<T>(
                url
            );
        } catch (e) {
            if (isAxiosError(e) && e.response) {
                return e.response.data;
            }
            return undefined;
        }
        return response.data;
    }

    protected async unauthoredPost<T>(url: string, data?: any): Promise<T | undefined> {
        let response: AxiosResponse<T>;
        try {
            response = await this.axios.post<T>(
                url,
                data
            );
        } catch (e) {
            if (isAxiosError(e) && e.response) {
                return e.response.data;
            }
            return undefined;
        }
        return response.data;
    }
}
