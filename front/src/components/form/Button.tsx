import { useState } from "react";
import IErrorDTO from "../../dto/IErrorDTO";
import { handleRequest } from "../../helpers/requestHelpers";

type Props<T> = {
    title: string;
    onClickRequest: () => Promise<T | IErrorDTO | undefined>;
    onSuccess: (response: T) => void;
};

export default function Button<T extends object>({title, onClickRequest, onSuccess}: Props<T>): JSX.Element {

    const [message, setMessage] = useState<string>("");

    function onClick(): void {
        handleRequest<T>(onClickRequest, setMessage, onSuccess);
    }

    return <>
        <div className="form-row">
            <button
                onClick={e => {e.preventDefault(); onClick();}}
            >
                {title}
            </button>
            <span>
                {message === "" ? <>&nbsp;</> : message}
            </span>
        </div>
    </>;
}
