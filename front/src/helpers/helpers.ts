import IErrorDTO from "../dto/IErrorDTO";

export async function handleRequest<T extends object>(
    request: () => Promise<T | IErrorDTO | undefined>,
    onError: (text: string) => void,
    onSuccess: (previous: T) => void
): Promise<void> {

    const response = await request();

    if (response === undefined) {
        onError("Axios problem");
    } else if ("errorMessage" in response) {
        onError(response.errorMessage);
    } else {
        onSuccess(response);
    }
}
