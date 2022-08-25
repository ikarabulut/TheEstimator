using Microsoft.AspNetCore.Mvc;
namespace TheEstimator.Controllers;

[ApiController]
[Route("[controller]")]
public class PertController : ControllerBase
{
    [HttpPost]
    public ActionResult Create(Estimate estimate)
    {
        
    }
}
