import { useLocation, useNavigate } from "react-router-dom";
import { useState, useContext } from "react";
import IdentityService from "../services/IdentityService";
import ILoginDTO from "../dto/identity/ILoginDTO";
import IJwtDTO from "../dto/identity/IJwtDTO";
import EmailInput from "../components/form/input/EmailInput";
import Button from "../components/form/Button";
import PasswordInputLogin from "../components/form/input/PasswordInputLogin";
import { setJwt } from "../jwtHelpers";
import { LoggedInContext } from "../App";

export default function Login(): JSX.Element {

    const {loggedIn, setLoggedIn} = useContext(LoggedInContext);

    //const location = useLocation();

    const navigate = useNavigate();

    const [dto, setDto] = useState<ILoginDTO>({
        email: "",
        password: ""
    });

    const identityService = new IdentityService();

    function onSuccess(response: IJwtDTO): void {
        setLoggedIn(true);

        setJwt(response);

        //console.log(location.state); TODO

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
    </>;
}
