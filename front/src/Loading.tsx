import { useEffect, useState } from "react";
import IErrorDTO from "./dto/IErrorDTO";
import { handleRequest } from "./helpers";

type Props<T extends object> = {
    request: () => Promise<T | IErrorDTO | undefined>;
    setter: (previous: T) => void;
};

export default function Loading<T extends object>({request, setter}: Props<T>): JSX.Element {

    const [error, setError] = useState<string>();

    useEffect(() => {
        handleRequest(request, setError, setter);
    }, []);

    return <>
        {error === undefined
            ? "Loading..."
            : error
        }
    </>;
}
