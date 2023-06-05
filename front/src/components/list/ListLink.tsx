import { Link } from "react-router-dom";

type Props = {
    to: string;
    text: string;
    onClick?: () => void;
};

export default function ListLink({text, to, onClick}: Props): JSX.Element {
    return <>
        <li>
            <Link to={to} onClick={onClick}>{text}</Link>
        </li>
    </>;
}
