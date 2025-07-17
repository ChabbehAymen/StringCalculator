using System.Linq.Expressions;

namespace StringCalculator.DelimiterSpecifications;

public class SpecifySingleDelimiterExpression : IDelimiterSpecification
{
    public int[] GetNumbers(ExpressionHandler expression)
    {
        return expression.WithSingleDelimiter();
    }
}
