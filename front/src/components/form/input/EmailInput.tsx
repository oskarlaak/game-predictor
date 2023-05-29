import { Dispatch, SetStateAction } from "react";
import Input from "./Input";

type Props<T> = {
    setDto: Dispatch<SetStateAction<T>>;
};

export default function EmailInput<T>({setDto}: Props<T>): JSX.Element {
    return <Input
        type="email"
        name="email"
        placeholder="Email"
        autoComplete="email"
        setDto={setDto}
    />;
}
