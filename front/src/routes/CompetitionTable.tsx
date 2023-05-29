export default function CompetitionTable(): JSX.Element {
    // const {jwt, setJwt} = useContext(JwtContext);

    // const competitionService = new CompetitionService(setJwt);

    // const [competition, setCompetition] = useState<ICompetitionDTO | undefined>(props.competition);
    // const [competitionTable, setCompetitionTable] = useState<ICompetitionTableDTO>();

    // const { id } = useParams();

    // useEffect(() => {
    //     if (jwt && competition === undefined) {
    //         competitionService.get(jwt, id!).then(response => {
                
    //         });
    //     }

    //     if (jwt && competition && competitionTable === undefined) {
    //         competitionService.getTable(jwt, competition?.id).then(response =>
    //             setCompetitionTable(response ?? [])
    //         );
    //     }
    // }, [jwt]);

    return (
        <h2>Table</h2>
    );
}
