import { Dispatch, SetStateAction } from "react";
import { capitalized } from "../../../helpers";

type Props<T> = {
    title: string;
    setDto: Dispatch<SetStateAction<T>>;
}

export default function TextInput<T>({title, setDto}: Props<T>) {

    function updateDto(e: HTMLInputElement) {
        setDto(previous => ({
            ...previous,
            [e.name]: e.value
        }));
    };

    title = title.toLowerCase();

    return <input
        onChange={e => updateDto(e.target)}
        placeholder={capitalized(title)}
        type="text"
        name={title}
    />;
}
