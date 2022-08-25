using Microsoft.AspNetCore.Mvc;
using TheEstimator.Controllers;

namespace TheEstimator.Tests.ControllersTests;

public class PertControllerTests
{
    [Fact]
    public void PertPost_Returns0_WhenModelStateIsAllZeros()
    {
        // Arrange
        var controller = new PertController();

        // Act
        var result = controller.Create();

        // Assert
        var expectedResult = Assert.IsType<CreatedAtAction>(result);
        Assert.IsType<SerializableError>(badRequestResult.Value);
    }
}
