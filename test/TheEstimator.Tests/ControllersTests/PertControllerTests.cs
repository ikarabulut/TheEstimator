using Microsoft.AspNetCore.Mvc;
using TheEstimator.Controllers;
using TheEstimator.EstimateCalculators;
using TheEstimator.Models;
using TheEstimator.Repository;

namespace TheEstimator.Tests.ControllersTests;

public class InMemoryRepositoryFake : IRepository
{
    private readonly List<Estimate> _estimates;
    public InMemoryRepositoryFake()
    {
        _estimates = new List<Estimate>();
    }
    public Estimate Add(Estimate newEstimate, IEstimateCalculator calculator)
    {
        newEstimate.Id = _estimates.Count + 1;
        newEstimate.CalculatedEstimate =
            calculator.CalculateEstimate(newEstimate.MostLikely, newEstimate.Optimistic, newEstimate.Pessimistic);
        _estimates.Add(newEstimate);
        return newEstimate;
    }

}

public class PertControllerTests
{
    private readonly PertController _controller;
    private readonly IRepository _repository;

    public PertControllerTests()
    {
        _repository = new InMemoryRepositoryFake();
        _controller = new PertController(_repository);
    }
    [Fact]
    public void Post_ValidObjectPassed_ReturnsCreatedResponse()
    {
        Estimate requestEstimate = new Estimate { Optimistic = 0, Pessimistic = 0, MostLikely = 0 };

        var createdResponse = _controller.Create(requestEstimate);

        Assert.IsType<CreatedAtActionResult>(createdResponse);
    }

    [Fact]
    public void Post_InvalidObjectPassed_ReturnsBadRequest()
    {
        Estimate invalidEstimate = new Estimate { Pessimistic = 0, MostLikely = 0 };
        _controller.ModelState.AddModelError("Optimistic", "Required");

        var badResponse = _controller.Create(invalidEstimate);

        Assert.IsType<BadRequestObjectResult>(badResponse);
    }

    [Fact]
    public void Post_ValidObjectPassed_ReturnedResponseHasCreatedEstimate()
    {
        Estimate requestEstimate = new Estimate { Optimistic = 0, Pessimistic = 0, MostLikely = 0 };

        var createdResponse = _controller.Create(requestEstimate) as CreatedAtActionResult;
        var estimate = createdResponse.Value as Estimate;

        Assert.IsType<Estimate>(estimate);
        Assert.Equal(0, estimate.CalculatedEstimate);
    }
}
