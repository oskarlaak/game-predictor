import { useState } from "react";
import IErrorDTO from "../../dto/IErrorDTO";
import { handleRequest } from "../../helpers/requestHelpers";

type Props<T extends object> = {
    title: string;
    onClickRequest: () => Promise<T | IErrorDTO | undefined>;
    onSuccess: (response: T) => void;
};

export default function Button<T extends object>({title, onClickRequest, onSuccess}: Props<T>): JSX.Element {

    const [message, setMessage] = useState<string>("");

    return <>
        <div>
            <button onClick={e => {
                e.preventDefault();
                handleRequest<T>(onClickRequest, setMessage, onSuccess);
            }}>
                {title}
            </button>
            <span className="invalid">
                {message !== "" ? message : <>&nbsp;</>}
            </span>
        </div>
    </>;
}
