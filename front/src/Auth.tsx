import { Navigate, useLocation } from "react-router-dom";
import { getJwt } from "./jwtHelpers";

type Props = {
    children: JSX.Element;
};

export default function Auth({children}: Props): JSX.Element {
    const location = useLocation();
  
    return getJwt()
        ? children
        : <Navigate to="/login" state={location} replace />;
}
