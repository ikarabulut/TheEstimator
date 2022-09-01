using TheEstimator.DataContext;
using TheEstimator.Models;

namespace TheEstimator.Repository;

public class EstimateRepository : IRepository
{
    private readonly EstimateContext _context;

    public EstimateRepository(EstimateContext context)
    {
        this._context = context;
    }

    public Estimate Add(Estimate newEstimate, int generatedEstimate)
    {
        newEstimate.CalculatedEstimate = generatedEstimate;
        _context.Estimates.Add(newEstimate);
        _context.SaveChanges();
        return newEstimate;
    }

    public List<Estimate> GetAll()
    {
        return _context.Estimates.ToList();
    }

    public Estimate Get(int id)
    {
        return _context.Estimates.Find(id);
    }
}
