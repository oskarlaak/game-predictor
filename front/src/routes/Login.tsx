import { useLocation, useNavigate } from "react-router-dom";
import { useState, useContext } from "react";
import UserAuthService from "../services/UserAuthService";
import ILoginDTO from "../dto/user-auth/ILoginDTO";
import IJwtDTO from "../dto/user-auth/IJwtDTO";
import Button from "../components/form/Button";
import { setJwt } from "../helpers/jwtHelpers";
import { LoggedInContext } from "../App";
import TextInput from "../components/form/input/TextInput";

export default function Login(): JSX.Element {

    const location = useLocation();

    const {loggedIn, setLoggedIn} = useContext(LoggedInContext);

    const navigate = useNavigate();

    const [dto, setDto] = useState<ILoginDTO>({
        email: "",
        password: ""
    });

    const userAuthService = new UserAuthService();

    function onSuccess(response: IJwtDTO): void {
        setLoggedIn(true);
        setJwt(response);
        navigate(location.state ?? "/");
    }

    function emailValidation(text: string): string {
        return "";
    }

    function passwordValidation(text: string): string {
        return "";
    }

    return <>
        <h1>Login</h1>
        <form>
            <TextInput
                type="email"
                name="email"
                placeholder="Email"
                autoComplete="email"
                validation={emailValidation}
                setDto={setDto}
            />
            <TextInput
                type="password"
                name="password"
                placeholder="Password"
                autoComplete="current-password"
                validation={passwordValidation}
                setDto={setDto}
            />
            <Button<IJwtDTO>
                title="Login"
                onClickRequest={() => userAuthService.login(dto)}
                onSuccess={onSuccess}
            />
        </form>
    </>;
}
