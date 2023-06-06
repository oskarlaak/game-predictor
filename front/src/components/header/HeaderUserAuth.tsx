import { useContext } from "react";
import { LoggedInContext } from "../../App";
import UserAuthService from "../../services/UserAuthService";
import { getJwt, removeJwt } from "../../helpers/jwtHelpers";
import ListLink from "../list/ListLink";
import jwt_decode from "jwt-decode";
import IJwtDTO from "../../dto/user-auth/IJwtDTO";

type DecodedJwt = {
    [key: string]: string;
};

export default function HeaderUserAuth(): JSX.Element {
    const {loggedIn, setLoggedIn} = useContext(LoggedInContext);

    const userAuthService = new UserAuthService();

    async function logout(): Promise<void> {
        await userAuthService.logout();
        setLoggedIn(false);
        removeJwt();
    }

    if (loggedIn) {
        const decodedJwt = jwt_decode<DecodedJwt>((getJwt() as IJwtDTO).token);

        const username = decodedJwt["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];

        return <>
            <ListLink to="/profile" text={username}/>
            <ListLink to="/" text="Logout" onClick={logout}/>
        </>;
    } else {
        return <>
            <ListLink to="/register" text="Register"/>
            <ListLink to="/login" text="Login"/>
        </>;
    }
}
