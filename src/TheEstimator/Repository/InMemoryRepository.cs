using TheEstimator.Models;

namespace TheEstimator.Repository;

public class InMemoryRepository : IRepository
{
    private List<Estimate> Estimates { get; }
    public InMemoryRepository()
    {
        Estimates = new List<Estimate>();
    }

    public Estimate Add(Estimate newEstimate, int generatedEstimate)
    {
        newEstimate.Id = Estimates.Count + 1;
        newEstimate.CalculatedEstimate = generatedEstimate;
        Estimates.Add(newEstimate);
        return newEstimate;
    }

    public List<Estimate> GetAll() => Estimates;

    public Estimate? Get(int id) => Estimates.FirstOrDefault(p => p.Id == id);

}
