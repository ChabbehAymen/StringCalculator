using System.Linq.Expressions;

namespace StringCalculator.DelimiterSpecifications;

public class SpecifySingleDelimiterExpression : IDelimiterSpecification
{
    public string[] GetNumbers(ExpressionHandler expression)
    {
        return expression.WithSingleDelimiter();
    }
}
