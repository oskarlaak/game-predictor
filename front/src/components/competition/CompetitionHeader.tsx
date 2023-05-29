import ICompetitionDTO from "../../dto/competition/ICompetitionDTO";

type Props = {
    c: ICompetitionDTO;
};

export default function CompetitionHeader({c}: Props): JSX.Element {
    return <>
        <h1>{c.name}</h1>
        {c.id} {c.type} {c.hasEnded} {c.userIsHost}
    </>;
}
