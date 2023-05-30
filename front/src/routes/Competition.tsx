import { useState } from "react";
import ICompetitionDTO from "../dto/competition/ICompetitionDTO";
import { Outlet, useLocation, useParams } from "react-router-dom";
import CompetitionService from "../services/CompetitionService";
import Loading from "../Loading";
import CompetitionHeader from "../components/competition/CompetitionHeader";

export default function Competition(): JSX.Element {

    const {id} = useParams();

    const location = useLocation();

    const competitionFromState = location.state ?? undefined;

    const [competition, setCompetition] = useState<ICompetitionDTO | undefined>(competitionFromState);

    const competitionService = new CompetitionService();

    if (id === undefined) {
        return <></>;
    }

    return <>
        {competition === undefined
            ? <Loading<ICompetitionDTO>
                request={() => competitionService.get(id)}
                setter={setCompetition}
            />
            : <><CompetitionHeader c={competition}/><Outlet/></>
        }
    </>;
}
