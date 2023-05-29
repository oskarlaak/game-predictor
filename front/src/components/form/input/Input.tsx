import { Dispatch, SetStateAction } from "react";

type Props<T> = {
    type: string;
    name: string;
    placeholder: string;
    autoComplete: string;
    setDto: Dispatch<SetStateAction<T>>;
};

export default function Input<T>({type, name, placeholder, autoComplete, setDto}: Props<T>): JSX.Element {

    function updateDto(e: EventTarget & HTMLInputElement): void {
        setDto(previous => ({
            ...previous,
            [e.name]: e.value
        }));
    }

    return <input
        type={type}
        name={name}
        placeholder={placeholder}
        autoComplete={autoComplete}
        onChange={e => updateDto(e.target)}
    />;
}
