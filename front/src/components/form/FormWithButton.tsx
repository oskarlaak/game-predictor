import { useState } from "react";
import IErrorDTO from "../../dto/IErrorDTO";
import { handleRequest } from "../../helpers/requestHelpers";

type Props<T> = {
    buttonTitle: string;
    onSubmitRequest: () => Promise<T | IErrorDTO | undefined>;
    onSuccess: (response: T) => void;
    children: JSX.Element | JSX.Element[];
};

export default function FormWithButton<T extends object>({
    buttonTitle,
    onSubmitRequest,
    onSuccess,
    children
}: Props<T>): JSX.Element {

    const [message, setMessage] = useState<string>("");

    const [loading, setLoading] = useState<boolean>(false);

    function onSubmit(): void {
        setMessage("");
        setLoading(true);
        handleRequest<T>(onSubmitRequest, setMessage, onSuccess);
    }

    return <>
        <form onSubmit={e => {e.preventDefault(); onSubmit();}}>
            {children}
            <div className="form-row">
                <button>
                    {buttonTitle}
                </button>
                <span className={message === "" ? "" : "invalid"}>
                    {message === ""
                        ? loading ? "Loading" : <>&nbsp;</>
                        : message
                    }
                </span>
            </div>
        </form>
    </>;
}
