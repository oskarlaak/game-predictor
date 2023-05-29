import { Dispatch, SetStateAction, useEffect, useState } from "react";
import IErrorDTO from "./dto/IErrorDTO";

type Props<T extends object> = {
    request: () => Promise<T | IErrorDTO | undefined>;
    setter: Dispatch<SetStateAction<T | undefined>>;
};

export default function Loading<T extends object>({request, setter}: Props<T>): JSX.Element {

    const [error, setError] = useState<string>();

    useEffect(() => {
        request().then(response => {
            if (response === undefined) {
                setError("Axios problem");
            } else if ("errorMessage" in response) {
                setError(response.errorMessage);
            } else {
                setter(response);
            }
        });
    }, []);

    return <>
        {error === undefined
            ? "Loading..."
            : error
        }
    </>;
}
