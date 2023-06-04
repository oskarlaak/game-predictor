import IErrorDTO from "../dto/IErrorDTO";

export async function handleRequest<T extends object>(
    request: () => Promise<T | IErrorDTO | undefined>,
    errorSetter: (text: string) => void,
    onSuccess: (previous: T) => void
): Promise<void> {

    const response = await request();

    if (response === undefined) {
        errorSetter("Axios problem");
    } else if ("errorMessage" in response) {
        errorSetter(response.errorMessage);
    } else {
        onSuccess(response);
    }
}
