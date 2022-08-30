namespace TheEstimator.EstimateCalculators;

public class PertCalculator : IEstimateCalculator
{
    public int CalculateEstimate(int mostLikely, int optimistic, int pessimistic)
    {
        ContainsNegativeParametersCheck(mostLikely, optimistic, pessimistic);

        return (optimistic + (4 * mostLikely) + pessimistic) / 6;
    }

    private void ContainsNegativeParametersCheck(int mostLikely, int optimistic, int pessimistic)
    {
        if (mostLikely < 0 || optimistic < 0 || pessimistic < 0)
            throw new ArgumentException("Values cannot be negative");
    }

}
