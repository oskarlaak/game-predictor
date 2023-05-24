import { Dispatch, SetStateAction } from "react";

type Props<T> = {
    setDto: Dispatch<SetStateAction<T>>
}

export default function EmailInput<T>({setDto}: Props<T>) {

    function updateDto(e: HTMLInputElement) {
        setDto(previous => ({
            ...previous,
            [e.name]: e.value
        }));
    };

    return <input
        onChange={e => updateDto(e.target)}
        placeholder="Email"
        autoComplete="email"
        type="email"
        name="email"
    />
}
