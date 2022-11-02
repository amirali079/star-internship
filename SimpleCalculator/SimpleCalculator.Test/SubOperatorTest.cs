using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Test;

public class SubOperatorTest
{
    [Fact]
    public void CalculateSub()
    {
        var subOperator = new SubOperator();

        var result = subOperator.Calculate(2, 1);
        
        Assert.Equal(1,result);

    }
}