using Microsoft.AspNetCore.Mvc;
using TheEstimator.Controllers;
using TheEstimator.EstimateCalculators;
using TheEstimator.Models;
using TheEstimator.Repository;

namespace TheEstimator.Tests.ControllersTests;

public class InMemoryRepositoryFake : IRepository
{
    private List<Estimate> Estimates { get; }
    public InMemoryRepositoryFake()
    {
        Estimates = new List<Estimate>
        {
            new()
            {
                Id = 1,
                MostLikely = 0,
                CalculatedEstimate = 0,
                Optimistic = 0,
                Pessimistic = 0
            }
        };

    }
    public Estimate Add(Estimate newEstimate, int generatedEstimate)
    {
        newEstimate.Id = Estimates.Count + 1;
        newEstimate.CalculatedEstimate = generatedEstimate;
        Estimates.Add(newEstimate);
        return newEstimate;
    }

    public List<Estimate> GetAll() => Estimates;

    public Estimate? Get(int id) => Estimates.FirstOrDefault(estimate => estimate.Id == id);


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
    public void Post_NegativeValuePassed_ReturnsBadRequest()
    {
        Estimate invalidEstimate = new Estimate { Optimistic = -1, Pessimistic = 0, MostLikely = 0 };
        _controller.ModelState.AddModelError("Optimistic", "Value cannot be negative");

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

    [Fact]
    public void Index_ReturnedResponseListsAllEstimates()
    {
        List<Estimate> expectedResponseValues = _repository.GetAll();

        ActionResult<List<Estimate>> createdResponse = _controller.Index();

        Assert.Equal(expectedResponseValues, createdResponse.Value);
    }

    [Fact]
    public void Get_ValidIdPassed_ReturnsIdMatchingEstimate()
    {
        const int validId = 1;
        Estimate expectedResponseValue = _repository.Get(validId);

        ActionResult<Estimate> createdResponse = _controller.Get(validId);

        Assert.Equal(expectedResponseValue, createdResponse.Value);
    }

    [Fact]
    public void Get_InvalidIdPassed_ReturnsNotFound()
    {
        const int invalidId = 2;

        ActionResult<Estimate> createdResponse = _controller.Get(invalidId);

        Assert.IsType<NotFoundResult>(createdResponse.Result);
    }
}
