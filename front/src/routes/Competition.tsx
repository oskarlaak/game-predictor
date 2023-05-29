import { useContext, useState } from "react";
import ICompetitionDTO from "../dto/competition/ICompetitionDTO";
import { JwtContext } from "../App";
import { Outlet, useLocation, useParams } from "react-router-dom";
import CompetitionService from "../services/CompetitionService";
import Loading from "../Loading";
import CompetitionHeader from "../components/competition/CompetitionHeader";

export default function Competition(): JSX.Element {

    const {jwt, setJwt} = useContext(JwtContext);

    const {id} = useParams();

    const location = useLocation();

    const [competition, setCompetition] = useState<ICompetitionDTO | undefined>(location.state ?? undefined);

    const competitionService = new CompetitionService(setJwt);

    if (jwt === null || id === undefined) {
        return <></>;
    }

    return <>
        {competition === undefined
            ? <Loading<ICompetitionDTO>
                request={() => competitionService.get(jwt, id)}
                setter={setCompetition}
            />
            : <><CompetitionHeader c={competition}/><Outlet/></>
        }
    </>;
}
