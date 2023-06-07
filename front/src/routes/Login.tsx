import { useLocation, useNavigate } from "react-router-dom";
import { useContext, useState} from "react";
import UserAuthService from "../services/UserAuthService";
import ILoginDTO from "../dto/user-auth/ILoginDTO";
import IJwtDTO from "../dto/user-auth/IJwtDTO";
import { setJwt } from "../helpers/jwtHelpers";
import { LoggedInContext } from "../App";
import FormWithButton from "../components/form/FormWithButton";
import TextInput from "../components/form/input/TextInput";

export default function Login(): JSX.Element {

    const {loggedIn, setLoggedIn} = useContext(LoggedInContext);

    const [dto, setDto] = useState<ILoginDTO>({
        email: "",
        password: ""
    });

    const navigate = useNavigate();

    const location = useLocation();

    const userAuthService = new UserAuthService();

    function onSuccess(response: IJwtDTO): void {
        setLoggedIn(true);
        setJwt(response);
        navigate(location.state ?? "/");
    }

    return <>
        <h1>Login</h1>
        <FormWithButton
            buttonTitle="Login"
            onSubmitRequest={() => userAuthService.login(dto)}
            onSuccess={onSuccess}
        >
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
                autoComplete="current-password"
                name="password"
                value={dto.password}
                setDto={setDto}
            />
        </FormWithButton>
    </>;
}
