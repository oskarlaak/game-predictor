import { Navigate, useLocation } from "react-router-dom";
import { getJwt } from "./jwtHelpers";
import { useContext } from "react";
import { LoggedInContext } from "./App";

type Props = {
    children: JSX.Element;
};

export default function Auth({children}: Props): JSX.Element {
    const location = useLocation();

    const {loggedIn, setLoggedIn} = useContext(LoggedInContext);
  
    return loggedIn
        ? children
        : <Navigate to="/login" state={location.pathname} replace />;
}
