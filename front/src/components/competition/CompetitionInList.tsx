import { Link } from "react-router-dom";
import ICompetitionDTO from "../../dto/competition/ICompetitionDTO";

type Props = {
    c: ICompetitionDTO;
};

export default function CompetitionInList({c}: Props): JSX.Element {
    return (
        <Link to={`c/${c.id}`} state={c}>
            {c.name} {c.type} {c.actionCount} {c.hasEnded} {c.userIsHost}
        </Link>
    );
}
