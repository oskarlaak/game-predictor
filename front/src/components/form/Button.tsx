import { useState } from "react";
import IErrorDTO from "../../dto/IErrorDTO";
import { handleRequest } from "../../helpers";

type Props<T extends object> = {
    title: string;
    onClickRequest: () => Promise<T | IErrorDTO | undefined>;
    onSuccess: (response: T) => void;
};

export default function Button<T extends object>({title, onClickRequest, onSuccess}: Props<T>): JSX.Element {

    const [error, setError] = useState<string>();

    return <>
        <button onClick={e => {
            e.preventDefault();
            handleRequest(onClickRequest, setError, onSuccess);
        }}>
            {title}
        </button>
        {error ?? ""}
    </>;
}
