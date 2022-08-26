namespace TheEstimator.EstimateCalculators;

public class PertCalculator
{
    public int CalculatePert(int mostLikely, int optimistic, int pessimistic)
    {
        return (optimistic + (4 * mostLikely) + pessimistic) / 6;
    }
}
