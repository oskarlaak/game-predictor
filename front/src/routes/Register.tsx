import { useNavigate } from "react-router-dom";
import { useState, useContext } from "react";
import UserAuthService from "../services/UserAuthService";
import IJwtDTO from "../dto/user-auth/IJwtDTO";
import IRegisterDTO from "../dto/user-auth/IRegisterDTO";
import { setJwt } from "../helpers/jwtHelpers";
import { LoggedInContext } from "../App";
import TextInput from "../components/form/input/TextInput";
import FormWithButton from "../components/form/FormWithButton";

export default function Register(): JSX.Element {

    const {loggedIn, setLoggedIn} = useContext(LoggedInContext);

    const [dto, setDto] = useState<IRegisterDTO>({
        username: "",
        email: "",
        password: "",
        confirmPassword: ""
    });

    const navigate = useNavigate();

    const userAuthService = new UserAuthService();

    function onSuccess(response: IJwtDTO): void {
        setLoggedIn(true);
        setJwt(response);
        navigate("/");
    }

    return <>
        <h1>Register</h1>
        <FormWithButton
            buttonTitle="Register"
            onSubmitRequest={() => userAuthService.register(dto)}
            onSuccess={onSuccess}
        >
            <TextInput
                title="Username"
                type="text"
                autoComplete="username"
                name="username"
                value={dto.username}
                setDto={setDto}
            />
            <TextInput
                title="Email"
                type="email"
                autoComplete="email"
                name="email"
                value={dto.email}
                setDto={setDto}
            />
            <TextInput
                title="Password"
                type="password"
                autoComplete="new-password"
                name="password"
                value={dto.password}
                setDto={setDto}
            />
            <TextInput
                title="Confirm Password"
                type="password"
                autoComplete="new-password"
                name="confirmPassword"
                value={dto.confirmPassword}
                setDto={setDto}
            />
        </FormWithButton>
    </>;
}
