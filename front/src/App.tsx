import { createContext, useState } from "react";
import { Routes, Route } from "react-router-dom";
import Competitions from "./routes/Competitions";
import Header from "./Header";
import Register from "./routes/Register";
import Login from "./routes/Login";
import IJwtDTO from "./dto/identity/IJwtDTO";
import Competition from "./routes/Competition";
import CompetitionTable from "./routes/CompetitionTable";
import CompetitionLeaderboard from "./routes/CompetitionLeaderboard";

interface IJwtContext {
    jwt: IJwtDTO | null;
    setJwt: (jwt: IJwtDTO | null) => void;
}

export const JwtContext = createContext<IJwtContext>({} as IJwtContext);

export default function App(): JSX.Element {
    const [jwt, setJwt] = useState<IJwtDTO | null>(null);

    return <JwtContext.Provider value={{ jwt, setJwt}}>
        <Header/>

        <Routes>
            <Route index element={<Competitions/>}/>
            <Route path="/c/:id" element={<Competition/>}>
                <Route index element={<CompetitionTable/>}/>
                <Route path="leaderboard" element={<CompetitionLeaderboard/>}/>
            </Route>
            <Route path="/register" element={<Register/>}/>
            <Route path="/login" element={<Login/>}/>
        </Routes>
    </JwtContext.Provider>;
}
