import { Routes, Route } from "react-router-dom";
import Competitions from "./routes/Competitions";
import Header from "./Header";
import Register from "./routes/Register";
import Login from "./routes/Login";
import Competition from "./routes/Competition";
import CompetitionTable from "./routes/CompetitionTable";
import CompetitionLeaderboard from "./routes/CompetitionLeaderboard";
import Auth from "./Auth";

export default function App(): JSX.Element {
    return <>
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
    </>;
}
