using TheEstimator.EstimateCalculators;

namespace TheEstimator.Tests.EstimateCalculatorsTests;

public class PertCalculatorTests
{
    [Fact]
    public void CreatePert_AllZeros_ReturnsZero()
    {
        PertCalculator calculator = new PertCalculator();
        const int expectedEstimate = 0;

        var returnedEstimate = calculator.CalculateEstimate(0, 0, 0);

        Assert.Equal(expectedEstimate, returnedEstimate);
    }
}
