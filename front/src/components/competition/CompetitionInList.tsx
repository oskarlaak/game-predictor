import { Link } from "react-router-dom";
import ICompetitionDTO from "../../dto/competition/ICompetitionDTO";

type Props = {
    c: ICompetitionDTO;
};

export default function CompetitionInList({c}: Props): JSX.Element {
    return <>
        <li><Link to={`c/${c.id}`}>{c.name}</Link></li>
    </>;
}
