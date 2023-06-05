import { Dispatch, SetStateAction } from "react";
import Input from "./Input";

type Props<T> = {
    setDto: Dispatch<SetStateAction<T>>;
};

export default function PasswordInputLogin<T>({setDto}: Props<T>): JSX.Element {
    return <>
        <Input
            type="password"
            name="password"
            placeholder="Password"
            autoComplete="current-password"
            setDto={setDto}
        />
    </>;
}
