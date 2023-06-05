import { Link } from "react-router-dom";
import HeaderUserAuth from "./HeaderUserAuth";

export default function Header(): JSX.Element {
    return <>
        <header>
            <nav>
                <Link to="/">GamePredictor</Link>
                <ul>
                    <HeaderUserAuth/>
                </ul>
            </nav>
        </header>
    </>;
}
