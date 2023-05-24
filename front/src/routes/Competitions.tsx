import { useContext, useState, useEffect } from "react";
import { JwtContext } from "../App";
import Loading from "../Loading";
import ICompetitionDTO from "../dto/competition/ICompetitionDTO";
import CompetitionList from "../components/competition/CompetitionList";
import CompetitionService from "../services/CompetitionService";

export default function Competitions() {

    const {jwt, setJwt} = useContext(JwtContext);

    const [competitions, setCompetitions] = useState<ICompetitionDTO[]>();

    const competitionService = new CompetitionService(setJwt);

    useEffect(() => {
        if (jwt && competitions === undefined) {
            competitionService.getAll(jwt).then(response =>
                setCompetitions(response ?? [])
            );
        }
    }, [jwt]);

    if (jwt === null) {
        return <></>;
    }

    return <>
        <h1>Competitions</h1>
        {competitions === undefined
            ? <Loading/>
            : <CompetitionList competitions={competitions}/>
        }
    </>;
}
