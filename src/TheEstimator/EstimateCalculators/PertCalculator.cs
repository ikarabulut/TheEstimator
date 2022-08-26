namespace TheEstimator.EstimateCalculators;

public class PertCalculator : IEstimateCalculator
{
    public int CalculateEstimate(int mostLikely, int optimistic, int pessimistic)
    {
        return (optimistic + (4 * mostLikely) + pessimistic) / 6;
    }

}
