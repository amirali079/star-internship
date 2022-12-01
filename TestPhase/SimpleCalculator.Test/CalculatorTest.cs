using SimpleCalculator.Business;
using SimpleCalculator.Business.Enums;

namespace SimpleCalculator.Test;

public class CalculatorTest
{
    [Fact]
    public void SumCalculateTest()
    {
        var calculator = new Calculator();

        var result = calculator.Calculate(1, 2, OperatorEnum.sum);
        
        Assert.Equal(3,result);
    }
    [Fact]
    public void SubCalculateTest()
    {
        var calculator = new Calculator();

        var result = calculator.Calculate(2, 1, OperatorEnum.sub);
        
        Assert.Equal(1,result);
    }
    [Fact]
    public void MultiplyCalculateTest()
    {
        var calculator = new Calculator();

        var result = calculator.Calculate(2, 2, OperatorEnum.multiply);
        
        Assert.Equal(4,result);
    }
    [Fact]
    public void ValidDivisionCalculateTest()
    {
        var calculator = new Calculator();

        var result = calculator.Calculate(6, 2, OperatorEnum.division);
        
        Assert.Equal(3,result);
    }
    [Fact]
    public void NotValidDivisionCalculateTest()
    {
        var calculator = new Calculator();

        Assert.Throws<DivideByZeroException>(() => calculator.Calculate(6, 0, OperatorEnum.division));
    }
    
}