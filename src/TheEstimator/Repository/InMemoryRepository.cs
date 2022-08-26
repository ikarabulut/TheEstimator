﻿using TheEstimator.EstimateCalculators;
using TheEstimator.Models;

namespace TheEstimator.Repository;

public class InMemoryRepository : IRepository
{
    private readonly List<Estimate> _estimates;
    public InMemoryRepository()
    {
        _estimates = new List<Estimate>();
    }

    public Estimate Add(Estimate newEstimate)
    {
        newEstimate.Id = _estimates.Count + 1;
        newEstimate.CalculatedEstimate =
            new PertCalculator().CalculateEstimate(newEstimate.MostLikely, newEstimate.Optimistic, newEstimate.Pessimistic);
        _estimates.Add(newEstimate);
        return newEstimate;
    }

}
