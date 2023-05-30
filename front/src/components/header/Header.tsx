import HeaderAuth from "./HeaderAuth";
import HeaderLink from "./HeaderLink";

export default function Header(): JSX.Element {
    return <header>
        <nav>
            <ul>
                <HeaderLink to="/" text="GamePredictor"/>
                <HeaderAuth/>
            </ul>
        </nav>
    </header>;
}
