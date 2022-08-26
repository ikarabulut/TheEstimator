using TheEstimator.EstimateCalculators;

namespace TheEstimator.Tests.EstimateTypeTests;

public class PertTests
{
    [Fact]
    public void CreatePert_AllZeros_ReturnsZero()
    {
        PertCalculator pert = new PertCalculator();
        const int expectedEstimate = 0;

        var returnedEstimate = pert.CalculatePert(0, 0, 0);

        Assert.Equal(expectedEstimate, returnedEstimate);
    }
}
