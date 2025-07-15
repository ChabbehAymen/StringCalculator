using StringCalculator.DelimiterSpecifications;

namespace StringCalculator;

public static class StringCalculatorOptions
{
    public static IDelimiterSpecification NoDelimiter => new SpecifyNoDelimiterExpression();
    public static IDelimiterSpecification SingleDelimiterExpression => new SpecifySingleDelimiterExpression();
}
