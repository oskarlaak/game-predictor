import { useState } from "react";
import Loading from "../Loading";
import ICompetitionDTO from "../dto/competition/ICompetitionDTO";
import CompetitionList from "../components/competition/CompetitionList";
import CompetitionService from "../services/CompetitionService";

export default function Competitions(): JSX.Element {

    const [competitions, setCompetitions] = useState<ICompetitionDTO[]>();

    const competitionService = new CompetitionService();

    return <>
        <h1>Competitions</h1>
        {competitions === undefined
            ? <Loading<ICompetitionDTO[]>
                request={() => competitionService.getAll()}
                setter={setCompetitions}
            />
            : <CompetitionList competitions={competitions}/>
        }
    </>;
}
