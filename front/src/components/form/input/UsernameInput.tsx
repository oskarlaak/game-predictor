import { Dispatch, SetStateAction } from "react";
import Input from "./Input";

type Props<T> = {
    setDto: Dispatch<SetStateAction<T>>;
};

export default function UsernameInput<T>({setDto}: Props<T>) {
    return <Input
        type="text"
        name="username"
        placeholder="Username"
        autoComplete="username"
        setDto={setDto}
    />;
}
