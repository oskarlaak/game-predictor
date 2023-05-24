import { Dispatch, SetStateAction } from "react";

type Props<T> = {
    setDto: Dispatch<SetStateAction<T>>;
}

export default function PasswordConfirmInputRegister<T>({setDto}: Props<T>) {

    function updateDto(e: HTMLInputElement) {
        setDto(previous => ({
            ...previous,
            [e.name]: e.value
        }));
    };

    return <input
        onChange={e => updateDto(e.target)}
        placeholder="Confirm Password"
        autoComplete="new-password"
        type="password"
        name="confirmPassword"
    />;
}
