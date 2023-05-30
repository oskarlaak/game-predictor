import { useContext, useEffect, useState, useRef } from "react";
import { ErrorContext } from "./App";

export default function ErrorPopup(): JSX.Element {

    const {error, setError} = useContext(ErrorContext);

    const [visible, setVisible] = useState<boolean>(false);

    const timerRef = useRef<number>();

    useEffect(() => {
        if (error !== "") {

            if (visible) {
                clearTimeout(timerRef.current);
            } else {
                setVisible(true);
            }

            timerRef.current = setTimeout(() => {
                setVisible(false);
                setError("");
            }, 3000);
        }
    }, [error]);

    return <span>{error}</span>;
}
