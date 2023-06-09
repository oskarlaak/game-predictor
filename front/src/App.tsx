import { Routes, Route } from "react-router-dom";
import Competitions from "./routes/Competitions";
import Header from "./components/header/Header";
import Register from "./routes/Register";
import Login from "./routes/Login";
import Auth from "./Auth";
import { createContext, useState } from "react";
import { hasJwt } from "./helpers/jwtHelpers";
import Profile from "./routes/Profile";
import Competition from "./routes/Competition";

interface ILoggedInContext {
    loggedIn: boolean;
    setLoggedIn: (loggedIn: boolean) => void;
}

export const LoggedInContext = createContext<ILoggedInContext>({} as ILoggedInContext);

export default function App(): JSX.Element {

    const [loggedIn, setLoggedIn] = useState<boolean>(hasJwt());

    return <>
        <LoggedInContext.Provider value={{loggedIn, setLoggedIn}}>
            <Header/>

            <main>
                <Routes>
                    <Route path="/" element={<Auth><Competitions/></Auth>}/>
                    <Route path="/c/:id" element={<Auth><Competition/></Auth>}/>
                    <Route path="/profile" element={<Auth><Profile/></Auth>}/>
                    <Route path="/register" element={<Register/>}/>
                    <Route path="/login" element={<Login/>}/>
                </Routes>
            </main>
        </LoggedInContext.Provider>
    </>;
}
