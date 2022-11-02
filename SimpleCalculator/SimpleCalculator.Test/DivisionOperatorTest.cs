using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Test;

public class DivisionOperatorTest
{
    [Fact]
    public void ValidCalculateDivision()
    {
        var divisionOperator = new DivisionOperator();

        var result = divisionOperator.Calculate(6, 2);
        
        Assert.Equal(3,result);

    }
    
    [Fact]
    public void NotValidCalculateDivision()
    {
        var divisionOperator = new DivisionOperator();

        Assert.Throws<DivideByZeroException>(()=>divisionOperator.Calculate(6, 0));

    }
}