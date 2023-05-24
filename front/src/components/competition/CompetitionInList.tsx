import { Link } from "react-router-dom"
import ICompetitionDTO from "../../dto/competition/ICompetitionDTO";

type Props = {
    c: ICompetitionDTO;
};

export default function CompetitionInList({c}: Props) {
    return (
        <Link to={`competition/${c.id}`}>
            {c.name} {c.type} {c.actionCount} {c.hasEnded} {c.userIsHost}
        </Link>
    );
}
