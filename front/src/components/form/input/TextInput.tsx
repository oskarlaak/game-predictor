import { Dispatch, SetStateAction, useState } from "react";

type Props<T> = {
    type: string;
    name: string;
    placeholder: string;
    autoComplete: string;

    validation: (text: string) => string;
    setDto: Dispatch<SetStateAction<T>>;
};

export default function TextInput<T>({type, name, placeholder, autoComplete, validation, setDto}: Props<T>): JSX.Element {

    const minWidth = 16;

    const [message, setMessage] = useState<string>("");
    const [width, setWidth] = useState<number>(minWidth);

    function trySetWidth(width: number) {
        if (width < minWidth) {
            width = minWidth;
        }
        setWidth(width);
    }

    function onChange(e: EventTarget & HTMLInputElement): void {
        const currentInput = e.value;

        setDto(previous => ({
            ...previous,
            [e.name]: currentInput
        }));

        setMessage(validation(currentInput));

        trySetWidth(currentInput.length);
    }

    const isInvalid = message !== "";

    return <>
        <div>
            <input
                className={isInvalid ? "invalid" : ""}
                style={{width: `${width}ch`}}
                type={type}
                name={name}
                placeholder={placeholder}
                autoComplete={autoComplete}
                onChange={e => onChange(e.target)}
            />
            <span className="invalid">
                {isInvalid ? message : <>&nbsp;</>}
            </span>
        </div>
    </>;
}
