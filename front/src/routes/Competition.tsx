import { useState, useEffect } from "react";
import ICompetitionTableDTO from "../dto/competition/ICompetitionTableDTO";
import CompetitionService from "../services/CompetitionService";
import { handleRequest } from "../helpers/requestHelpers";
import { useParams } from "react-router-dom";
import CompetitionTable from "../components/competition-table/CompetitionTable";

export default function Competition(): JSX.Element {

    const {id} = useParams();

    const [competition, setCompetition] = useState<ICompetitionTableDTO>();

    const [error, setError] = useState<string>("");

    const competitionService = new CompetitionService();

    useEffect(() => {
        if (id) {
            handleRequest(() => competitionService.getTable(id), setError, setCompetition);
        }
    }, [id]);

    return <>
        {error !== ""
            ? error
            : competition === undefined
                ? "Loading"
                : <CompetitionTable c={competition}/> 
        }
    </>;
}
