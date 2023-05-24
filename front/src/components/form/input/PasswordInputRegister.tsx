import { Dispatch, SetStateAction } from "react";

type Props<T> = {
    setDto: Dispatch<SetStateAction<T>>;
}

export default function PasswordInputRegister<T>({setDto}: Props<T>) {

    function updateDto(e: HTMLInputElement) {
        setDto(previous => ({
            ...previous,
            [e.name]: e.value
        }));
    };

    return <input
        onChange={e => updateDto(e.target)}
        placeholder="Password"
        autoComplete="new-password"
        type="password"
        name="password"
    />;
}
