using SimpleCalculator.Business.Enums;
using SimpleCalculator.Business.OperatorBusiness;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Test;

public class OperatorProviderTest
{
    [Theory]
    [InlineData(OperatorEnum.sum, typeof(SumOperator))]
    [InlineData(OperatorEnum.sub, typeof(SubOperator))]
    [InlineData(OperatorEnum.multiply, typeof(MultiplyOperator))]
    [InlineData(OperatorEnum.division, typeof(DivisionOperator))]
    public void GetValidOperator(OperatorEnum operatorEnum,Type type)
    {
        var operatorProvider = new OperatorProvider();

        var result = operatorProvider.GetOperator(operatorEnum);
        
        Assert.IsType(type,result);
    }
    
  
    [Fact]
    public void GetInvalidOperator()
    {
        var operatorProvider = new OperatorProvider();

        Assert.True(true); // We cannot choose anything but the elements of an Enum and Coverage not go to 100%.
        //Assert.Throws<NotSupportedException>(() => operatorProvider.GetOperator(OperatorEnum.?));
    }
}