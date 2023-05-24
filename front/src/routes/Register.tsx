import { useNavigate } from "react-router-dom";
import { useState, useContext } from "react";
import { JwtContext } from "../App";
import IdentityService from "../services/IdentityService";
import IJwtDTO from "../dto/identity/IJwtDTO";
import EmailInput from "../components/form/input/EmailInput";
import Button from "../components/form/Button";
import IRegisterDTO from "../dto/identity/IRegisterDTO";
import PasswordInputRegister from "../components/form/input/PasswordInputRegister";
import PasswordConfirmInputRegister from "../components/form/input/PasswordConfirmInputRegister";
import UsernameInput from "../components/form/input/UsernameInput";

export default function Register() {
    const {jwt, setJwt} = useContext(JwtContext);

    const navigate = useNavigate();

    const [dto, setDto] = useState<IRegisterDTO>({
        username: "",
        email: "",
        password: "",
        confirmPassword: ""
    });

    const identityService = new IdentityService(setJwt);

    function onSuccess(response: IJwtDTO) {
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
    </>
}
