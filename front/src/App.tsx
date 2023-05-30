import { Routes, Route } from "react-router-dom";
import Competitions from "./routes/Competitions";
import Header from "./components/header/Header";
import Register from "./routes/Register";
import Login from "./routes/Login";
import Competition from "./routes/Competition";
import CompetitionTable from "./routes/CompetitionTable";
import CompetitionLeaderboard from "./routes/CompetitionLeaderboard";
import Auth from "./Auth";
import { createContext, useState } from "react";
import { hasJwt } from "./jwtHelpers";

interface ILoggedInContext {
    loggedIn: boolean;
    setLoggedIn: (loggedIn: boolean) => void;
}

export const LoggedInContext = createContext<ILoggedInContext>({} as ILoggedInContext);

export default function App(): JSX.Element {

    const [loggedIn, setLoggedIn] = useState<boolean>(hasJwt());

    return <LoggedInContext.Provider value={{loggedIn, setLoggedIn}}>
        <Header/>

        <Routes>
            <Route index element={<Auth><Competitions/></Auth>}/>
            <Route path="/c/:id" element={<Auth><Competition/></Auth>}>
                <Route index element={<CompetitionTable/>}/>
                <Route path="leaderboard" element={<CompetitionLeaderboard/>}/>
            </Route>
            <Route path="/register" element={<Register/>}/>
            <Route path="/login" element={<Login/>}/>
        </Routes>
    </LoggedInContext.Provider>;
}
