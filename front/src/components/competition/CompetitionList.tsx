import ICompetitionDTO from "../../dto/competition/ICompetitionDTO";
import CompetitionInList from "./CompetitionInList";

type Props = {
    competitions: ICompetitionDTO[];
};

export default function CompetitionList({competitions}: Props): JSX.Element {
    return <>
        <ul>
            {competitions.map(c => <CompetitionInList c={c}/>)}
        </ul>
    </>;
}
