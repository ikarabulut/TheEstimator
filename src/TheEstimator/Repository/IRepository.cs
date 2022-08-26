using TheEstimator.Models;

namespace TheEstimator.Repository;

public interface IRepository
{
    Estimate Add(Estimate newEstimate);
}
