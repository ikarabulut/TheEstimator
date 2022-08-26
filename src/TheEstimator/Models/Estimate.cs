namespace TheEstimator.Models;

public class Estimate
{
    public int Id { get; set; }
    public int MostLikely { get; set; }
    public int Optimistic { get; set; }
    public int Pessimistic { get; set; }
    public int CalculatedEstimate { get; set; }

}
