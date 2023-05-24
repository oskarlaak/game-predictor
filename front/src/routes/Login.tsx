import { useNavigate } from "react-router-dom";
import { useState, useContext } from "react";
import { JwtContext } from "../App";
import IdentityService from "../services/IdentityService";
import ILoginDTO from "../dto/identity/ILoginDTO";
import IJwtDTO from "../dto/identity/IJwtDTO";
import EmailInput from "../components/form/input/EmailInput";
import Button from "../components/form/Button";
import PasswordInputLogin from "../components/form/input/PasswordInputLogin";

export default function Login() {

    const {jwt, setJwt} = useContext(JwtContext);

    const navigate = useNavigate();

    const [dto, setDto] = useState<ILoginDTO>({
        email: "",
        password: ""
    });

    const identityService = new IdentityService(setJwt);

    function onSuccess(response: IJwtDTO) {
        setJwt(response);
        navigate("/");
    }

    return <>
        <h1>Login</h1>
        <form>
            <EmailInput
                setDto={setDto}
            />
            <PasswordInputLogin
                setDto={setDto}
            />
            <Button<IJwtDTO>
                title="Login"
                onClickRequest={() => identityService.login(dto)}
                onSuccess={onSuccess}
            />
        </form>
    </>
}
