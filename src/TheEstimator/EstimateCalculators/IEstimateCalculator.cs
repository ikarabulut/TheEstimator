namespace TheEstimator.EstimateCalculators;

public interface IEstimateCalculator
{
    int CalculateEstimate(int mostLikely, int optimistic, int pessimistic);
}
