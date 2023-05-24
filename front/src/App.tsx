import { createContext, useState } from "react";
import { Routes, Route } from "react-router-dom";
import Competitions from "./routes/Competitions";
import Header from "./Header";
import Register from "./routes/Register";
import Login from "./routes/Login";
import IJwtDTO from "./dto/identity/IJwtDTO";

interface IJwtContext {
    jwt: IJwtDTO | null;
    setJwt: (jwt: IJwtDTO | null) => void;
}

export const JwtContext = createContext<IJwtContext>({} as IJwtContext);

export default function App() {
    const [jwt, setJwt] = useState<IJwtDTO | null>(null);

    return <JwtContext.Provider value={{ jwt, setJwt}}>
        <Header/>

        <Routes>
            <Route path="/" element={<Competitions/>}/>
            <Route path="/register" element={<Register/>}/>
            <Route path="/login" element={<Login/>}/>
        </Routes>
    </JwtContext.Provider>;
}
