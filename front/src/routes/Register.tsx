import { useNavigate } from "react-router-dom";
import { useState, useContext } from "react";
import IdentityService from "../services/IdentityService";
import IJwtDTO from "../dto/identity/IJwtDTO";
import EmailInput from "../components/form/input/EmailInput";
import Button from "../components/form/Button";
import IRegisterDTO from "../dto/identity/IRegisterDTO";
import PasswordInputRegister from "../components/form/input/PasswordInputRegister";
import PasswordConfirmInputRegister from "../components/form/input/PasswordConfirmInputRegister";
import UsernameInput from "../components/form/input/UsernameInput";
import { setJwt } from "../jwtHelpers";
import { LoggedInContext } from "../App";

export default function Register(): JSX.Element {

    const {loggedIn, setLoggedIn} = useContext(LoggedInContext);

    const navigate = useNavigate();

    const [dto, setDto] = useState<IRegisterDTO>({
        username: "",
        email: "",
        password: "",
        confirmPassword: ""
    });

    const identityService = new IdentityService();

    function onSuccess(response: IJwtDTO): void {
        setLoggedIn(true);

        setJwt(response);
        navigate("/");
    }

    return <>
        <h1>Register</h1>
        <form>
            <UsernameInput
                setDto={setDto}
            />
            <EmailInput
                setDto={setDto}
            />
            <PasswordInputRegister
                setDto={setDto}
            />
            <PasswordConfirmInputRegister
                setDto={setDto}
            />
            <Button<IJwtDTO>
                title="Register"
                onClickRequest={() => identityService.register(dto)}
                onSuccess={onSuccess}
            />
        </form>
    </>;
}
