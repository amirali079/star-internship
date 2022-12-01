using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Test;

public class MultiplyOperatorTest
{
    [Fact]
    public void CalculateMultiply()
    {
        var multiplyOperator = new MultiplyOperator();

        var result = multiplyOperator.Calculate(2, 2);
        
        Assert.Equal(4,result);

    }
}