using Microsoft.AspNetCore.Mvc;
using TheEstimator.Models;
using TheEstimator.Repository;

namespace TheEstimator.Controllers;

[ApiController]
[Route("[controller]")]
public class PertController : ControllerBase
{
    private readonly IRepository _repository;

    public PertController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public IActionResult Create(Estimate estimate)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdEstimate = _repository.Add(estimate);

        return CreatedAtAction(nameof(Create), new { id = createdEstimate.Id }, createdEstimate);
    }

}
