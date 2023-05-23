import { Routes, Route } from "react-router-dom";
import Competitions from "./routes/Competitions";

export default function App() {
    return (
        <Routes>
            <Route path="/" element={<Competitions/>}/>
        </Routes>
    );
}
