using TheEstimator.EstimateCalculators;

namespace TheEstimator.Tests.EstimateCalculatorsTests;

public class PertCalculatorTests
{
    [Fact]
    public void CreateEstimate_AllZeros_ReturnsZero()
    {
        PertCalculator calculator = new PertCalculator();
        const int expectedEstimate = 0;

        var returnedEstimate = calculator.CalculateEstimate(0, 0, 0);

        Assert.Equal(expectedEstimate, returnedEstimate);
    }

    [Fact]
    public void CreateEstimate_WithNegativeParam_ThrowsIllegalArgumentException()
    {
        PertCalculator calculator = new PertCalculator();
        var disallowedNegativeParam = -1;
    
        Assert.Throws<ArgumentException>(() => calculator.CalculateEstimate(disallowedNegativeParam, 0, 0));
    }
}
