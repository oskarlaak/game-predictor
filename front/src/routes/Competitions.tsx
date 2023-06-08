import CompetitionList from "../components/competition/CompetitionList";
import ICompetitionDTO from "../dto/competition/ICompetitionDTO";
import { handleRequest } from "../helpers/requestHelpers";
import CompetitionService from "../services/CompetitionService";
import { useState, useEffect } from "react";

export default function Competitions(): JSX.Element {

    const [competitions, setCompetitions] = useState<ICompetitionDTO[]>();

    const [error, setError] = useState<string>("");

    const competitionService = new CompetitionService();

    useEffect(() => {
        handleRequest(() => competitionService.getAll(), setError, setCompetitions);
    }, []);

    return <>
        <h1>My Competitions</h1>

        {error !== ""
            ? error
            : competitions === undefined
                ? "Loading"
                : <CompetitionList competitions={competitions}/>
        }
    </>;
}
