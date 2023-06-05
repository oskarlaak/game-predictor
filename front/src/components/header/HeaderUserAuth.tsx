import { useContext } from "react";
import { LoggedInContext } from "../../App";
import UserAuthService from "../../services/UserAuthService";
import { removeJwt } from "../../helpers/jwtHelpers";
import ListLink from "../list/ListLink";

export default function HeaderUserAuth(): JSX.Element {
    const {loggedIn, setLoggedIn} = useContext(LoggedInContext);

    const userAuthService = new UserAuthService();

    async function logout(): Promise<void> {
        await userAuthService.logout();
        setLoggedIn(false);
        removeJwt();
    }

    if (loggedIn) {
        return <>
            <ListLink to="/" text="Logout" onClick={logout}/>
        </>;
    } else {
        return <>
            <ListLink to="/register" text="Register"/>
            <ListLink to="/login" text="Login"/>
        </>;
    }
}
