import { useNavigate } from "react-router-dom";
import { useState, useContext } from "react";
import { JwtContext } from "../App";
import IdentityService from "../services/IdentityService";
import IJwtDTO from "../dto/identity/IJwtDTO";
import IErrorDTO from "../dto/IErrorDTO";
import EmailInput from "../components/form/input/EmailInput";
import Button from "../components/form/Button";
import IRegisterDTO from "../dto/identity/IRegisterDTO";
import TextInput from "../components/form/input/TextInput";
import PasswordInputRegister from "../components/form/input/PasswordInputRegister";
import PasswordConfirmInputRegister from "../components/form/input/PasswordConfirmInputRegister";

export default function Register() {
    const {jwt, setJwt} = useContext(JwtContext);

    const navigate = useNavigate();

    const [error, setError] = useState<string>("");

    const [dto, setDto] = useState<IRegisterDTO>({
        username: "",
        email: "",
        password: "",
        confirmPassword: ""
    });

    const identityService = new IdentityService(setJwt);

    async function register() {
        let response: IJwtDTO | IErrorDTO | undefined = await identityService.register(dto);

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
        <h1>Register</h1>
        <form>
            <TextInput
                title="Username"
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
            <Button
                title="Register"
                onClick={register}
            />
            {error}
        </form>
    </>
}
