import { Link } from "react-router-dom";

type Props = {
    to: string;
    text: string;
    beforeNavigate?: () => void;
};

export default function HeaderLink({to, text, beforeNavigate}: Props): JSX.Element {
    return <>
        <li>
            <Link to={to} onClick={beforeNavigate}>{text}</Link>
        </li>
    </>;
}
