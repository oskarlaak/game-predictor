import { useNavigate } from "react-router-dom";
import { useState, useContext } from "react";
import { JwtContext } from "../App";
import IdentityService from "../services/IdentityService";
import ILoginDTO from "../dto/identity/ILoginDTO";
import IJwtDTO from "../dto/identity/IJwtDTO";
import IErrorDTO from "../dto/IErrorDTO";
import EmailInput from "../components/form/input/EmailInput";
import Button from "../components/form/Button";
import PasswordInputLogin from "../components/form/input/PasswordInputLogin";

export default function Login() {

    const {jwt, setJwt} = useContext(JwtContext);

    const navigate = useNavigate();

    const [error, setError] = useState<string>("");

    const [dto, setDto] = useState<ILoginDTO>({
        email: "",
        password: ""
    });

    const identityService = new IdentityService(setJwt);

    async function login() {
        let response: IJwtDTO | IErrorDTO | undefined = await identityService.login(dto);

        if (response === undefined) {
            setError("Axios problem");
        } else if ("errorMessage" in response) {
            setError(response.errorMessage);
        } else {
            setJwt(response);
            navigate("/");
        }
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
            <Button
                title="Login"
                onClick={login}
            />
            {error}
        </form>
    </>
}
