using TheEstimator.EstimateCalculators;
using TheEstimator.Models;

namespace TheEstimator.Repository;

public interface IRepository
{
    Estimate Add(Estimate newEstimate, IEstimateCalculator calculator);
}
