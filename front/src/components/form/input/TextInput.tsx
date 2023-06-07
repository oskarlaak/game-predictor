import { Dispatch, SetStateAction, useState } from "react";

type Props<T> = {
    title: string;
    type: string;
    autoComplete: string;
    name: string;
    value: string;
    setDto: Dispatch<SetStateAction<T>>;
};

export default function TextInput<T>({
    title,
    type,
    autoComplete,
    name,
    value,
    setDto
}: Props<T>): JSX.Element {

    const minWidth = 16;

    const [width, setWidth] = useState<number>(minWidth);

    function trySetWidth(width: number): void {
        if (width < minWidth) {
            width = minWidth;
        }
        setWidth(width);
    }

    function onChange(e: EventTarget & HTMLInputElement): void {
        setDto(previous => ({
            ...previous,
            [e.name]: e.value
        }));

        trySetWidth(e.value.length);
    }

    return <>
        <label className="form-row">
            {title}
            <input
                style={{width: `${width}ch`}}

                type={type}
                autoComplete={autoComplete}
                name={name}
                value={value}
                onChange={e => onChange(e.target)}
            />
        </label>
    </>;
}
