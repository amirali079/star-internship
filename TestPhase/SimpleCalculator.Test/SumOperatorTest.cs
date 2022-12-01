using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Test;

public class SumOperatorTest
{
    [Fact]
    public void CalculateSum()
    {
        var sumOperator = new SumOperator();

        var result = sumOperator.Calculate(1, 2);
        
        Assert.Equal(3,result);

    }
}