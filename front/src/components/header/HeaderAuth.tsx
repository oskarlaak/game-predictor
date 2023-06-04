import { LoggedInContext } from "../../App";
import { removeJwt } from "../../helpers/jwtHelpers";
import IdentityService from "../../services/UserAuthService";
import HeaderLink from "./HeaderLink";
import { useContext } from "react";

export default function HeaderAuth(): JSX.Element {

    const {loggedIn, setLoggedIn} = useContext(LoggedInContext);

    const identityService = new IdentityService();

    async function logout(): Promise<void> {
        setLoggedIn(false);
        await identityService.logout();
        removeJwt();
    }

    if (loggedIn) {
        return <>
            <HeaderLink to="/" text="Logout" beforeNavigate={logout}/>
        </>;
    } else {
        return <>
            <HeaderLink to="/register" text="Register"/>
            <HeaderLink to="/login" text="Login"/>
        </>;
    }
}
