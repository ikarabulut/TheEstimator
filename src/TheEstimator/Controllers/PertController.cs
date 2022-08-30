using Microsoft.AspNetCore.Mvc;
using TheEstimator.EstimateCalculators;
using TheEstimator.Models;
using TheEstimator.Repository;

namespace TheEstimator.Controllers;

[ApiController]
[Route("[controller]")]
public class PertController : ControllerBase
{
    private readonly IRepository _repository;
    private readonly IEstimateCalculator _calculator;

    public PertController(IRepository repository)
    {
        _repository = repository;
        _calculator = new PertCalculator();
    }

    [HttpPost]
    public IActionResult Create(Estimate estimate)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var CalculatedEstimate =
            _calculator.CalculateEstimate(estimate.MostLikely, estimate.Optimistic, estimate.Pessimistic);
        
        var createdEstimate = _repository.Add(estimate, CalculatedEstimate);

        return CreatedAtAction(nameof(Create), new { id = createdEstimate.Id }, createdEstimate);
    }

}
