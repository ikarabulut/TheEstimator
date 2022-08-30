using TheEstimator.EstimateCalculators;
using TheEstimator.Models;

namespace TheEstimator.Repository;

public interface IRepository
{
    Estimate Add(Estimate newEstimate, int generatedEstimate);

    List<Estimate> GetAll();

    Estimate? Get(int id);
}
