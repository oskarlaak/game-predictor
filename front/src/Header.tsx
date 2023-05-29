import { Link } from "react-router-dom";

export default function Header(): JSX.Element {
    return <header>
        <nav>
            <ul>
                <li>
                    <Link to="/">GamePredictor</Link>
                </li>
                <li>
                    <Link to="/register">Register</Link>
                </li>
                <li>
                    <Link to="/login">Login</Link>
                </li>
            </ul>
        </nav>
    </header>;
}
