import { Dispatch, SetStateAction } from "react";
import Input from "./Input";

type Props<T> = {
    setDto: Dispatch<SetStateAction<T>>;
};

export default function PasswordInputRegister<T>({setDto}: Props<T>): JSX.Element {
    return <>
        <Input
            type="password"
            name="password"
            placeholder="Password"
            autoComplete="new-password"
            setDto={setDto}
        />
    </>;
}
