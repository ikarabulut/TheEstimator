namespace TheEstimator.EstimateTypes;

public class PertEstimate
{
    public int CreatePert(int mostLikely, int optimistic, int pessimistic)
    {
        return (optimistic + (4 * mostLikely) + pessimistic) / 6;
    }
}
