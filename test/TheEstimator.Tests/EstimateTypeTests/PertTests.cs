using TheEstimator.EstimateTypes;

namespace TheEstimator.Tests.EstimateTypeTests;

public class PertTests
{
    [Fact]
    public void CreatePert_AllZeros_ReturnsZero()
    {
        PertEstimate pert = new PertEstimate();
        const int expectedEstimate = 0;

        var returnedEstimate = pert.CreatePert(0, 0, 0);

        Assert.Equal(expectedEstimate, returnedEstimate);
    }
}
