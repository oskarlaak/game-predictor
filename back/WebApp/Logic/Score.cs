namespace WebApp.Logic;

public class Score
{
    private readonly int? _teamOne;
    private readonly int? _teamTwo;
    private readonly int? _difference;
    
    public Score(int? teamOne, int? teamTwo)
    {
        _teamOne = teamOne;
        _teamTwo = teamTwo;
        _difference = _teamOne - _teamTwo;
    }
    
    public bool IsNull()
    {
        return _teamOne == null ||
               _teamTwo == null;
    }

    public bool Equals(Score other)
    {
        return _teamOne == other._teamOne &&
               _teamTwo == other._teamTwo;
    }

    public bool HasEqualScoreDifference(Score other)
    {
        return _difference == other._difference;
    }
    
    public bool HasEqualNormalizedScoreDifference(Score other)
    {
        return NormalizedDifference() == other.NormalizedDifference();
    }

    private int? NormalizedDifference()
    {
        if (_difference > 0) return 1;
        if (_difference < 0) return -1;
        return _difference;
    }
}
