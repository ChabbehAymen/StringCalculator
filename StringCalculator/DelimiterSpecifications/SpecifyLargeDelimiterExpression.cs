namespace StringCalculator.DelimiterSpecifications;

public class SpecifyLargeDelimiterExpression : IDelimiterSpecification
{
    public int[] GetNumbers(ExpressionHandler expression)
    {
        return expression.WithLargeDelimiter();
    }
}