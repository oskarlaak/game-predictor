import { Dispatch, SetStateAction } from "react";
import Input from "./Input";

type Props<T> = {
    setDto: Dispatch<SetStateAction<T>>;
};

export default function PasswordConfirmInputRegister<T>({setDto}: Props<T>): JSX.Element {
    return <>
        <Input
            type="password"
            name="confirmPassword"
            placeholder="Confirm Password"
            autoComplete="new-password"
            setDto={setDto}
        />
    </>;
}
