using System.ComponentModel.DataAnnotations;

namespace TheEstimator.Models;

public class Estimate
{
    public int Id { get; set; }
    
    [Range(0, int.MaxValue, ErrorMessage = "Value cannot be negative")]
    public int MostLikely { get; set; }
    
    [Range(0, int.MaxValue, ErrorMessage = "Value cannot be negative")]
    public int Optimistic { get; set; }
    
    [Range(0, int.MaxValue, ErrorMessage = "Value cannot be negative")]
    public int Pessimistic { get; set; }
    public int CalculatedEstimate { get; set; }

}
