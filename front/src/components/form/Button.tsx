import { useState } from "react";
import IErrorDTO from "../../dto/IErrorDTO";

type Props<T extends object> = {
    title: string;
    onClickRequest: () => Promise<T | IErrorDTO | undefined>;
    onSuccess: (response: T) => void;
}

export default function Button<T extends object>({title, onClickRequest, onSuccess}: Props<T>) {

    const [error, setError] = useState<string>("");

    async function onClick() {
        let response: T | IErrorDTO | undefined = await onClickRequest();

        if (response === undefined) {
            setError("Axios problem");
        } else if ("errorMessage" in response) {
            setError(response.errorMessage);
        } else {
            onSuccess(response);
        }
    }

    return <>
        <button onClick={e => {e.preventDefault(); onClick()}}>
            {title}
        </button>
        {error}
    </>;
}
