namespace BLL.App.Logic;

public class PointsCalculator
{
    private readonly int _pointsOnCorrectScore;
    private readonly int _pointsOnCorrectScoreDifference;
    private readonly int _pointsOnCorrectResult;

    public PointsCalculator(
        int pointsOnCorrectScore,
        int pointsOnCorrectScoreDifference,
        int pointsOnCorrectResult)
    {
        _pointsOnCorrectScore = pointsOnCorrectScore;
        _pointsOnCorrectScoreDifference = pointsOnCorrectScoreDifference;
        _pointsOnCorrectResult = pointsOnCorrectResult;
    }

    public int? Calculate(Score actual, Score prediction)
    {
        if (actual.IsNull() || prediction.IsNull()) return null;

        if (actual.Equals(prediction)) return _pointsOnCorrectScore;

        if (actual.HasEqualScoreDifference(prediction)) return _pointsOnCorrectScoreDifference;

        if (actual.HasEqualNormalizedScoreDifference(prediction)) return _pointsOnCorrectResult;

        return 0;
    }
}
