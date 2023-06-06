import { useNavigate } from "react-router-dom";
import { useState, useContext } from "react";
import UserAuthService from "../services/UserAuthService";
import IJwtDTO from "../dto/user-auth/IJwtDTO";
import Button from "../components/form/Button";
import IRegisterDTO from "../dto/user-auth/IRegisterDTO";
import { setJwt } from "../helpers/jwtHelpers";
import { LoggedInContext } from "../App";
import TextInput from "../components/form/input/TextInput";

export default function Register(): JSX.Element {

    const {loggedIn, setLoggedIn} = useContext(LoggedInContext);

    const navigate = useNavigate();

    const [dto, setDto] = useState<IRegisterDTO>({
        username: "",
        email: "",
        password: "",
        confirmPassword: ""
    });

    const userAuthService = new UserAuthService();

    function onSuccess(response: IJwtDTO): void {
        setLoggedIn(true);
        setJwt(response);
        navigate("/");
    }

    function usernameValidation(text: string): string {
        return "";
    }

    function emailValidation(text: string): string {
        return "";
    }

    function passwordValidation(text: string): string {
        return "";
    }

    function confirmPasswordValidation(text: string): string {
        return "";
    }

    return <>
        <h1>Register</h1>
        <form>
            <TextInput
                type="text"
                name="username"
                placeholder="Username"
                autoComplete="username"
                validation={usernameValidation}
                setDto={setDto}
            />
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
                autoComplete="new-password"
                validation={passwordValidation}
                setDto={setDto}
            />
            <TextInput
                type="password"
                name="confirmPassword"
                placeholder="Confirm Password"
                autoComplete="new-password"
                validation={confirmPasswordValidation}
                setDto={setDto}
            />
            <Button<IJwtDTO>
                title="Register"
                onClickRequest={() => userAuthService.register(dto)}
                onSuccess={onSuccess}
            />
        </form>
    </>;
}
