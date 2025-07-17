using StringCalculator.DelimiterSpecifications;

namespace StringCalculator;

public static class DelimiterSpecificationFactory
{
    public static IDelimiterSpecification NoDelimiter => new SpecifyNoDelimiterExpression();
    public static IDelimiterSpecification SingleDelimiterExpression => new SpecifySingleDelimiterExpression();

    public static IDelimiterSpecification LargeDelimiterExpression => new SpecifyLargeDelimiterExpression();
}
