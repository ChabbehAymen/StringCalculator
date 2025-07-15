namespace StringCalculator.DelimiterSpecifications;

public class SpecifyNoDelimiterExpression : IDelimiterSpecification
{
    public string[] GetNumbers(ExpressionHandler expression)
    {
        return expression.WithSplitters();
    }
}
